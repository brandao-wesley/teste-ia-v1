# Quality Gate determinístico v6.9.0

Status: APROVADO
Categoria: passed
Motivo: Cópia limpa executada diretamente no host; script, health, Swagger, CRUD e reinício aprovados.
Cobertura: 90.07%
Meta de cobertura: 90.00%
SecurityBlocking: false

## Critérios
- Estrutura: aprovada
- Build: aprovado
- Testes: aprovados
- Cobertura: aprovada
- Segurança: aprovada

## Comandos executados
### Clean host customer startup
- Exit code: 0
- Sucesso: sim
```text
Determinando os projetos a serem restaurados...
  C:\Users\brand\AppData\Local\FabulosoftIA\acceptance\task_23\clean-clone\src\ApiDeClientesTesteDevAgent.Application\ApiDeClientesTesteDevAgent.Application.csproj restaurado (em 46 ms).
  C:\Users\brand\AppData\Local\FabulosoftIA\acceptance\task_23\clean-clone\src\ApiDeClientesTesteDevAgent.Domain\ApiDeClientesTesteDevAgent.Domain.csproj restaurado (em 43 ms).
  C:\Users\brand\AppData\Local\FabulosoftIA\acceptance\task_23\clean-clone\src\ApiDeClientesTesteDevAgent.Infrastructure\ApiDeClientesTesteDevAgent.Infrastructure.csproj restaurado (em 177 ms).
  C:\Users\brand\AppData\Local\FabulosoftIA\acceptance\task_23\clean-clone\src\ApiDeClientesTesteDevAgent.Api\ApiDeClientesTesteDevAgent.Api.csproj restaurado (em 185 ms).
  ApiDeClientesTesteDevAgent.Domain -> C:\Users\brand\AppData\Local\FabulosoftIA\acceptance\task_23\clean-clone\src\ApiDeClientesTesteDevAgent.Domain\bin\Release\net8.0\ApiDeClientesTesteDevAgent.Domain.dll
  ApiDeClientesTesteDevAgent.Application -> C:\Users\brand\AppData\Local\FabulosoftIA\acceptance\task_23\clean-clone\src\ApiDeClientesTesteDevAgent.Application\bin\Release\net8.0\ApiDeClientesTesteDevAgent.Application.dll
  ApiDeClientesTesteDevAgent.Infrastructure -> C:\Users\brand\AppData\Local\FabulosoftIA\acceptance\task_23\clean-clone\src\ApiDeClientesTesteDevAgent.Infrastructure\bin\Release\net8.0\ApiDeClientesTesteDevAgent.Infrastructure.dll
  ApiDeClientesTesteDevAgent.Api -> C:\Users\brand\AppData\Local\FabulosoftIA\acceptance\task_23\clean-clone\src\ApiDeClientesTesteDevAgent.Api\bin\Release\net8.0\ApiDeClientesTesteDevAgent.Api.dll

Compilação com êxito.
    0 Aviso(s)
    0 Erro(s)

Tempo Decorrido 00:00:01.26
Projeto pronto em http://127.0.0.1:62512 (PID 20096)
```

### Clean host customer shutdown
- Exit code: 0
- Sucesso: sim
```text

```

### Clean host customer restart
- Exit code: 0
- Sucesso: sim
```text
Determinando os projetos a serem restaurados...
  C:\Users\brand\AppData\Local\FabulosoftIA\acceptance\task_23\clean-clone\src\ApiDeClientesTesteDevAgent.Application\ApiDeClientesTesteDevAgent.Application.csproj restaurado (em 48 ms).
  C:\Users\brand\AppData\Local\FabulosoftIA\acceptance\task_23\clean-clone\src\ApiDeClientesTesteDevAgent.Domain\ApiDeClientesTesteDevAgent.Domain.csproj restaurado (em 44 ms).
  C:\Users\brand\AppData\Local\FabulosoftIA\acceptance\task_23\clean-clone\src\ApiDeClientesTesteDevAgent.Infrastructure\ApiDeClientesTesteDevAgent.Infrastructure.csproj restaurado (em 162 ms).
  C:\Users\brand\AppData\Local\FabulosoftIA\acceptance\task_23\clean-clone\src\ApiDeClientesTesteDevAgent.Api\ApiDeClientesTesteDevAgent.Api.csproj restaurado (em 167 ms).
  ApiDeClientesTesteDevAgent.Domain -> C:\Users\brand\AppData\Local\FabulosoftIA\acceptance\task_23\clean-clone\src\ApiDeClientesTesteDevAgent.Domain\bin\Release\net8.0\ApiDeClientesTesteDevAgent.Domain.dll
  ApiDeClientesTesteDevAgent.Application -> C:\Users\brand\AppData\Local\FabulosoftIA\acceptance\task_23\clean-clone\src\ApiDeClientesTesteDevAgent.Application\bin\Release\net8.0\ApiDeClientesTesteDevAgent.Application.dll
  ApiDeClientesTesteDevAgent.Infrastructure -> C:\Users\brand\AppData\Local\FabulosoftIA\acceptance\task_23\clean-clone\src\ApiDeClientesTesteDevAgent.Infrastructure\bin\Release\net8.0\ApiDeClientesTesteDevAgent.Infrastructure.dll
  ApiDeClientesTesteDevAgent.Api -> C:\Users\brand\AppData\Local\FabulosoftIA\acceptance\task_23\clean-clone\src\ApiDeClientesTesteDevAgent.Api\bin\Release\net8.0\ApiDeClientesTesteDevAgent.Api.dll

Compilação com êxito.
    0 Aviso(s)
    0 Erro(s)

Tempo Decorrido 00:00:00.74
Projeto pronto em http://127.0.0.1:62512 (PID 10780)
```

### Clean host final cleanup
- Exit code: 0
- Sucesso: sim
```text

```

## Contrato de decisão
- A fonte única de verdade é `.fabulosoft/quality-result.json`.
- Falhas são reparadas no workspace atual; não há novo clone durante autocorreção.
- Cobertura baixa gera testes orientados pelas linhas/branches descobertos.
- Publicação Git exige build, testes, cobertura e segurança aprovados.
