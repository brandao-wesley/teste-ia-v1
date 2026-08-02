$ErrorActionPreference = "Stop"
dotnet restore .\ApiDeClientesTesteDevAgent.sln
dotnet run --project .\src\ApiDeClientesTesteDevAgent.Api\ApiDeClientesTesteDevAgent.Api.csproj
