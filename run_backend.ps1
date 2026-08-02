param(
    [int]$Port = 8080,
    [switch]$Detached,
    [switch]$Down
)
$ErrorActionPreference = "Stop"
Set-Location $PSScriptRoot
# Fabulosoft v6.9.9: Windows native dependency path preflight
# SQLite/e_sqlite3 and other native dependencies can fail on deeply nested
# extracted Git/ZIP paths. Keep the proven launcher unchanged for safe paths,
# but fail early with an actionable message instead of a long native stacktrace.
$maxSafeProjectRootLength = 140
if ($PSScriptRoot.Length -gt $maxSafeProjectRootLength) {
    throw "Caminho do projeto muito longo ($($PSScriptRoot.Length) caracteres). Mova ou extraia o projeto para um caminho curto, por exemplo C:\\Projetos\\MinhaApi, e execute novamente."
}

$runtimeDir = Join-Path $PSScriptRoot ".runtime"
$pidFile = Join-Path $runtimeDir "app.pid"
$stdoutFile = Join-Path $runtimeDir "app.stdout.log"
$stderrFile = Join-Path $runtimeDir "app.stderr.log"
New-Item -ItemType Directory -Force -Path $runtimeDir | Out-Null

if ($Down) {
    if (Test-Path $pidFile) {
        $savedPid = Get-Content $pidFile -ErrorAction SilentlyContinue
        if ($savedPid) {
            & taskkill.exe /PID ([int]$savedPid) /T /F 2>$null | Out-Null
            Stop-Process -Id ([int]$savedPid) -Force -ErrorAction SilentlyContinue
        }
        Remove-Item $pidFile -Force -ErrorAction SilentlyContinue
    }
    exit 0
}

if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
    throw ".NET SDK não encontrado. Instale o SDK compatível com global.json."
}

# Restore/build the actual executable project. A malformed or minimal .sln must
# never produce a false successful build with no application binary.
dotnet restore "src\ApiDeClientesTesteDevAgent.Api\ApiDeClientesTesteDevAgent.Api.csproj" --force-evaluate
if ($LASTEXITCODE -ne 0) { throw "Falha no restore do projeto da API." }
dotnet build "src\ApiDeClientesTesteDevAgent.Api\ApiDeClientesTesteDevAgent.Api.csproj" --configuration Release --no-restore
if ($LASTEXITCODE -ne 0) { throw "Falha no build do projeto da API." }

# Customer usage: run_backend.ps1 -Detached or -Down. dotnet run is executed below through Start-Process/argument array.
$arguments = @("run", "--project", "src\ApiDeClientesTesteDevAgent.Api\ApiDeClientesTesteDevAgent.Api.csproj", "--configuration", "Release", "--no-build", "--urls", "http://127.0.0.1:$Port")
if (-not $Detached) {
    & dotnet @arguments
    exit $LASTEXITCODE
}

Remove-Item $stdoutFile,$stderrFile -Force -ErrorAction SilentlyContinue
$process = Start-Process dotnet -ArgumentList $arguments -WorkingDirectory $PSScriptRoot -PassThru -WindowStyle Hidden -RedirectStandardOutput $stdoutFile -RedirectStandardError $stderrFile
Set-Content -Path $pidFile -Value $process.Id
$deadline = (Get-Date).AddSeconds(120)
$health = "http://127.0.0.1:$Port/health"
while ((Get-Date) -lt $deadline) {
    $process.Refresh()
    if ($process.HasExited) {
        $out = if (Test-Path $stdoutFile) { Get-Content $stdoutFile -Raw -ErrorAction SilentlyContinue } else { "" }
        $err = if (Test-Path $stderrFile) { Get-Content $stderrFile -Raw -ErrorAction SilentlyContinue } else { "" }
        throw "A aplicação encerrou antes de ficar pronta (exit=$($process.ExitCode)).`nSTDOUT:`n$out`nSTDERR:`n$err"
    }
    try {
        $response = Invoke-WebRequest -UseBasicParsing -Uri $health -TimeoutSec 3
        if ($response.StatusCode -eq 200) {
            Write-Host "Projeto pronto em http://127.0.0.1:$Port (PID $($process.Id))"
            exit 0
        }
    } catch {}
    Start-Sleep -Seconds 2
}
$out = if (Test-Path $stdoutFile) { Get-Content $stdoutFile -Raw -ErrorAction SilentlyContinue } else { "" }
$err = if (Test-Path $stderrFile) { Get-Content $stderrFile -Raw -ErrorAction SilentlyContinue } else { "" }
Stop-Process -Id $process.Id -Force -ErrorAction SilentlyContinue
throw "Timeout aguardando /health.`nSTDOUT:`n$out`nSTDERR:`n$err"
