# Quality Gate determinístico v6.7.5

Status: APROVADO
Categoria: passed
Motivo: Build, testes, cobertura, estrutura, dependências e segurança aprovados.
Cobertura: 98.63%
Meta de cobertura: 90.00%
SecurityBlocking: false

## Critérios
- Estrutura: aprovada
- Build: aprovado
- Testes: aprovados
- Cobertura: aprovada
- Segurança: aprovada

## Comandos executados
### dotnet restore solution
- Exit code: 0
- Sucesso: sim
```text
Determinando os projetos a serem restaurados...
C:\Program Files\dotnet\sdk\8.0.423\NuGet.targets(174,5): warning : NÃ£o Ã© possÃ­vel encontrar um projeto para restaurar! [C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\ApiDeClientesTesteDevAgent.sln]
```

### dotnet build solution
- Exit code: 0
- Sucesso: sim
```text
CompilaÃ§Ã£o com Ãªxito.
    0 Aviso(s)
    0 Erro(s)

Tempo Decorrido 00:00:00.06
```

### dotnet test coverage ApiDeClientesTesteDevAgent.UnitTests.csproj
- Exit code: 0
- Sucesso: sim
```text
Determinando os projetos a serem restaurados...
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\src\ApiDeClientesTesteDevAgent.Application\ApiDeClientesTesteDevAgent.Application.csproj restaurado (em 42 ms).
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\src\ApiDeClientesTesteDevAgent.Domain\ApiDeClientesTesteDevAgent.Domain.csproj restaurado (em 40 ms).
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\tests\ApiDeClientesTesteDevAgent.UnitTests\ApiDeClientesTesteDevAgent.UnitTests.csproj restaurado (em 140 ms).
  ApiDeClientesTesteDevAgent.Domain -> C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\src\ApiDeClientesTesteDevAgent.Domain\bin\Release\net8.0\ApiDeClientesTesteDevAgent.Domain.dll
  ApiDeClientesTesteDevAgent.Application -> C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\src\ApiDeClientesTesteDevAgent.Application\bin\Release\net8.0\ApiDeClientesTesteDevAgent.Application.dll
  ApiDeClientesTesteDevAgent.UnitTests -> C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\tests\ApiDeClientesTesteDevAgent.UnitTests\bin\Release\net8.0\ApiDeClientesTesteDevAgent.UnitTests.dll
Execução de teste para C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\tests\ApiDeClientesTesteDevAgent.UnitTests\bin\Release\net8.0\ApiDeClientesTesteDevAgent.UnitTests.dll (.NETCoreApp,Version=v8.0)
Versão do VSTest 17.11.1 (x64)

Iniciando execução de teste, espere...
1 arquivos de teste no total corresponderam ao padrão especificado.

Aprovado!  � Com falha:     0, Aprovado:    27, Ignorado:     0, Total:    27, Duração: 120 ms - ApiDeClientesTesteDevAgent.UnitTests.dll (net8.0)

Anexos:
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\.fabulosoft\TestResults\test_1\728b4fe7-e0fe-4e20-a3e0-479453520162\coverage.cobertura.xml
```

### dotnet sdk version
- Exit code: 0
- Sucesso: sim
```text
8.0.423
```

### dotnet restore audit ApiDeClientesTesteDevAgent.Api.csproj
- Exit code: 0
- Sucesso: sim
```text
Determinando os projetos a serem restaurados...
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\src\ApiDeClientesTesteDevAgent.Application\ApiDeClientesTesteDevAgent.Application.csproj restaurado (em 47 ms).
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\src\ApiDeClientesTesteDevAgent.Domain\ApiDeClientesTesteDevAgent.Domain.csproj restaurado (em 44 ms).
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\src\ApiDeClientesTesteDevAgent.Infrastructure\ApiDeClientesTesteDevAgent.Infrastructure.csproj restaurado (em 184 ms).
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\src\ApiDeClientesTesteDevAgent.Api\ApiDeClientesTesteDevAgent.Api.csproj restaurado (em 210 ms).
```

### dotnet vulnerable packages ApiDeClientesTesteDevAgent.Api.csproj
- Exit code: 0
- Sucesso: sim
```text
{
  "version": 1,
  "parameters": "--vulnerable --include-transitive",
  "sources": [
    "https://api.nuget.org/v3/index.json"
  ],
  "projects": [
    {
      "path": "C:/Users/brand/AppData/Local/FabulosoftIA/data/dev_workspaces/task_1/repo/src/ApiDeClientesTesteDevAgent.Api/ApiDeClientesTesteDevAgent.Api.csproj"
    }
  ]
}
```

### dotnet restore audit ApiDeClientesTesteDevAgent.Application.csproj
- Exit code: 0
- Sucesso: sim
```text
Determinando os projetos a serem restaurados...
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\src\ApiDeClientesTesteDevAgent.Domain\ApiDeClientesTesteDevAgent.Domain.csproj restaurado (em 39 ms).
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\src\ApiDeClientesTesteDevAgent.Application\ApiDeClientesTesteDevAgent.Application.csproj restaurado (em 40 ms).
```

### dotnet vulnerable packages ApiDeClientesTesteDevAgent.Application.csproj
- Exit code: 0
- Sucesso: sim
```text
{
  "version": 1,
  "parameters": "--vulnerable --include-transitive",
  "sources": [
    "https://api.nuget.org/v3/index.json"
  ],
  "projects": [
    {
      "path": "C:/Users/brand/AppData/Local/FabulosoftIA/data/dev_workspaces/task_1/repo/src/ApiDeClientesTesteDevAgent.Application/ApiDeClientesTesteDevAgent.Application.csproj"
    }
  ]
}
```

### dotnet restore audit ApiDeClientesTesteDevAgent.Infrastructure.csproj
- Exit code: 0
- Sucesso: sim
```text
Determinando os projetos a serem restaurados...
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\src\ApiDeClientesTesteDevAgent.Domain\ApiDeClientesTesteDevAgent.Domain.csproj restaurado (em 39 ms).
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\src\ApiDeClientesTesteDevAgent.Application\ApiDeClientesTesteDevAgent.Application.csproj restaurado (em 40 ms).
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\src\ApiDeClientesTesteDevAgent.Infrastructure\ApiDeClientesTesteDevAgent.Infrastructure.csproj restaurado (em 129 ms).
```

### dotnet vulnerable packages ApiDeClientesTesteDevAgent.Infrastructure.csproj
- Exit code: 0
- Sucesso: sim
```text
{
  "version": 1,
  "parameters": "--vulnerable --include-transitive",
  "sources": [
    "https://api.nuget.org/v3/index.json"
  ],
  "projects": [
    {
      "path": "C:/Users/brand/AppData/Local/FabulosoftIA/data/dev_workspaces/task_1/repo/src/ApiDeClientesTesteDevAgent.Infrastructure/ApiDeClientesTesteDevAgent.Infrastructure.csproj"
    }
  ]
}
```

### dotnet restore audit ApiDeClientesTesteDevAgent.UnitTests.csproj
- Exit code: 0
- Sucesso: sim
```text
Determinando os projetos a serem restaurados...
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\src\ApiDeClientesTesteDevAgent.Application\ApiDeClientesTesteDevAgent.Application.csproj restaurado (em 38 ms).
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\src\ApiDeClientesTesteDevAgent.Domain\ApiDeClientesTesteDevAgent.Domain.csproj restaurado (em 38 ms).
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\tests\ApiDeClientesTesteDevAgent.UnitTests\ApiDeClientesTesteDevAgent.UnitTests.csproj restaurado (em 126 ms).
```

### dotnet vulnerable packages ApiDeClientesTesteDevAgent.UnitTests.csproj
- Exit code: 0
- Sucesso: sim
```text
{
  "version": 1,
  "parameters": "--vulnerable --include-transitive",
  "sources": [
    "https://api.nuget.org/v3/index.json"
  ],
  "projects": [
    {
      "path": "C:/Users/brand/AppData/Local/FabulosoftIA/data/dev_workspaces/task_1/repo/tests/ApiDeClientesTesteDevAgent.UnitTests/ApiDeClientesTesteDevAgent.UnitTests.csproj"
    }
  ]
}
```

## Contrato de decisão
- A fonte única de verdade é `.fabulosoft/quality-result.json`.
- Falhas são reparadas no workspace atual; não há novo clone durante autocorreção.
- Cobertura baixa gera testes orientados pelas linhas/branches descobertos.
- Publicação Git exige build, testes, cobertura e segurança aprovados.
