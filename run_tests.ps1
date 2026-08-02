$ErrorActionPreference = "Stop"
$solution = Get-ChildItem -Path . -File | Where-Object { $_.Extension -in @('.sln','.slnx') } | Select-Object -First 1
if (-not $solution) { throw "Nenhuma solução .sln/.slnx encontrada." }
dotnet restore $solution.FullName
dotnet build $solution.FullName --configuration Release --no-restore
dotnet test $solution.FullName --configuration Release --no-build --collect:"XPlat Code Coverage"
