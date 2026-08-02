param([int]$Port = 5100)
$ErrorActionPreference = "Stop"
$solution = Get-ChildItem -Path . -File | Where-Object { $_.Extension -in @('.sln','.slnx') } | Select-Object -First 1
if (-not $solution) { throw "Nenhuma solução .sln/.slnx encontrada." }
for ($p=$Port; $p -lt ($Port+30); $p++) { if (-not (Get-NetTCPConnection -LocalPort $p -ErrorAction SilentlyContinue)) { $Port=$p; break } }
$env:ASPNETCORE_URLS = "http://127.0.0.1:$Port"
dotnet restore $solution.FullName
dotnet run --project .\src\ApiDeClientesTesteDevAgent.Api\ApiDeClientesTesteDevAgent.Api.csproj
