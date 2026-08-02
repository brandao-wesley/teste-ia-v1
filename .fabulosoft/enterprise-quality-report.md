# Quality Gate determinístico v6.7.5

Status: REPROVADO
Categoria: coverage_low
Motivo: Cobertura real 82.19% abaixo da meta 90%.
Cobertura: 82.19%
Meta de cobertura: 90.00%
SecurityBlocking: false

## Critérios
- Estrutura: aprovada
- Build: aprovado
- Testes: aprovados
- Cobertura: reprovada
- Segurança: não executada

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
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\src\ApiDeClientesTesteDevAgent.Domain\ApiDeClientesTesteDevAgent.Domain.csproj restaurado (em 51 ms).
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\src\ApiDeClientesTesteDevAgent.Application\ApiDeClientesTesteDevAgent.Application.csproj restaurado (em 51 ms).
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\tests\ApiDeClientesTesteDevAgent.UnitTests\ApiDeClientesTesteDevAgent.UnitTests.csproj restaurado (em 165 ms).
  ApiDeClientesTesteDevAgent.Domain -> C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\src\ApiDeClientesTesteDevAgent.Domain\bin\Release\net8.0\ApiDeClientesTesteDevAgent.Domain.dll
  ApiDeClientesTesteDevAgent.Application -> C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\src\ApiDeClientesTesteDevAgent.Application\bin\Release\net8.0\ApiDeClientesTesteDevAgent.Application.dll
  ApiDeClientesTesteDevAgent.UnitTests -> C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\tests\ApiDeClientesTesteDevAgent.UnitTests\bin\Release\net8.0\ApiDeClientesTesteDevAgent.UnitTests.dll
Execução de teste para C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\tests\ApiDeClientesTesteDevAgent.UnitTests\bin\Release\net8.0\ApiDeClientesTesteDevAgent.UnitTests.dll (.NETCoreApp,Version=v8.0)
Versão do VSTest 17.11.1 (x64)

Iniciando execução de teste, espere...
1 arquivos de teste no total corresponderam ao padrão especificado.

Aprovado!  � Com falha:     0, Aprovado:     8, Ignorado:     0, Total:     8, Duração: 177 ms - ApiDeClientesTesteDevAgent.UnitTests.dll (net8.0)

Anexos:
  C:\Users\brand\AppData\Local\FabulosoftIA\data\dev_workspaces\task_1\repo\.fabulosoft\TestResults\test_1\4d231eef-9898-408f-bcd1-17a5d0d90905\coverage.cobertura.xml
```

## Contrato de decisão
- A fonte única de verdade é `.fabulosoft/quality-result.json`.
- Falhas são reparadas no workspace atual; não há novo clone durante autocorreção.
- Cobertura baixa gera testes orientados pelas linhas/branches descobertos.
- Publicação Git exige build, testes, cobertura e segurança aprovados.


BLOQUEADO: Cobertura real 82.19% abaixo da meta 90%.
