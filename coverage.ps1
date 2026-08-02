$ErrorActionPreference = "Stop"
dotnet test .\ApiDeClientesTesteDevAgent.sln --configuration Release --collect:"XPlat Code Coverage"
