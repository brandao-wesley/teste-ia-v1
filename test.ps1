$ErrorActionPreference = "Stop"
dotnet restore .\ApiDeClientesTesteDevAgent.sln
dotnet build .\ApiDeClientesTesteDevAgent.sln --configuration Release --no-restore
dotnet test .\ApiDeClientesTesteDevAgent.sln --configuration Release --no-build
