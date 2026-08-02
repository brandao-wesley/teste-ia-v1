# API de Clientes - Teste DEV Agent

Projeto C#/.NET (net8.0) gerado pelo Fabulosoft Dev Agent seguindo Clean Architecture, DDD, SOLID, injeção de dependência e testes unitários abrangentes.

## Estrutura

- `src/ApiDeClientesTesteDevAgent.Domain`: entidades, value objects, contratos e regras de domínio.
- `src/ApiDeClientesTesteDevAgent.Application`: DTOs, serviços de aplicação, validação e casos de uso.
- `src/ApiDeClientesTesteDevAgent.Infrastructure`: persistência EF Core, repositórios e injeção de infraestrutura.
- `src/ApiDeClientesTesteDevAgent.Api`: inicialização, controllers, settings, Swagger e endpoints.
- `tests/ApiDeClientesTesteDevAgent.UnitTests`: testes unitários das regras de domínio e aplicação.

## Rodar API

```powershell
.\run_backend.ps1
```

## Rodar testes com cobertura

```powershell
.\run_tests.ps1
```

## Instrução original

FABULOSOFT_DEV_CONTRACT_V610
Tipo de projeto: api
Stack contratada: dotnet-clean-api
Backend: dotnet-clean-api
Frontend: NÃO CRIAR FRONTEND
Politica Git: pull_request_humano
Modo repo Git: existente_ou_novo
Branch de passagem: dev-agent/staging
Regras obrigatórias:
- Obedecer exatamente o tipo de projeto contratado.
- Se tipo = api/worker/cli/library/microservice, não criar React, Blazor, Angular, Vue ou Web.
- Rodar build/test/cobertura/smoke test e auditoria de vulnerabilidades quando aplicável.
- Em Git, criar branch feature-dev-agent-nome-reduzido-task-id, preparar rollback e abrir PR para revisão humana.
- Não fazer merge automático para dev/main.
FIM_CONTRATO_DEV_AGENT
Crie uma API REST em .NET 8 para gerenciamento de clientes.
 
Requisitos:
 
- DDD e Clean Architecture.
- Projetos:
  - Domain
  - Application
  - Infrastructure
  - API
  - Tests
- Entidade Cliente:
  - Id
  - Nome
  - Email
  - Documento
  - Ativo
  - CriadoEm
- CRUD completo.
- PostgreSQL.
- Entity Framework Core.
- Swagger.
- Health Check.
- Tratamento global de erros.
- Logs estruturados.
- Validações.
- Testes unitários.
- Cobertura mínima de 90% para Domain e Application.
- Testes de integração dos endpoints principais.
- Dockerfile.
- docker-compose.
- README.
- .env.example.
- Não inserir credenciais reais.

## Rotas iniciais

Ao rodar a API, a raiz `/` redireciona para `/swagger`, evitando 404 ao abrir o projeto no navegador.

Rotas úteis:

- `/` → Swagger
- `/swagger` → documentação interativa da API
- `/health` → health check
- `/api` → resumo da API
- `/api/customers` → CRUD de clientes

## Padrões empresariais aplicados pelo Dev Agent

# Dev Agent Enterprise Context

Stack detectada: dotnet-clean-api

## Quality Gate obrigatório
- Cobertura mínima: 80%
- Tentativas de autocorreção: 3
- Bloquear ZIP em falha: sim
- Bloquear Git/PR em falha: sim

## Playbooks aplicáveis
### Fabulosoft Backend .NET Clean Architecture
Escopo: backend | Stack: dotnet-clean-api
Usar Clean Architecture com src/<Projeto>.Api, Application, Domain e Infrastructure. Controllers não devem conter regra de negócio. DTOs em Application/DTOs. Interfaces começam com I. Repositories em Infrastructure. Testes com xUnit, Moq e Coverlet. README, run.ps1, test.ps1 e coverage.ps1 obrigatórios. Build/test/cobertura antes de ZIP ou Git.

## Repositórios/Pastas modelo
- Nenhuma referência cadastrada.
