# API de Fornecedores - Teste DEV Agent — Documentação do Projeto

> Documento gerado automaticamente pelo Fabulosoft Dev Agent após geração/evolução e antes da entrega.

## 1. Resumo executivo

FABULOSOFT_PROJECT_EVOLUTION_V6101
Modo: EVOLUCAO_INCREMENTAL_SEGURA
Regras obrigatorias de regressao zero:
- Clonar/abrir o projeto existente e criar branch nova.
- Não recriar, substituir ou apagar funcionalidades anteriores.
- Criar arquivos do novo escopo e editar arquivos compartilhados somente quando necessário.
- Rodar todos os testes antigos e novos; cobertura global do projeto inteiro acima de 90%.
- Validar em cópia limpa todos os endpoints antigos e novos antes do Git.
- Criar documentation/PROJECT_DOCUMENTATION.html e PROJECT_DOCUMENTATION.md completos.
FIM_FABULOSOFT_PROJECT_EVOLUTION_V6101

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
Atualize essa API REST em .NET 8 incluindo gerenciamento de fornecedores.
Requisitos:
- DDD e Clean Architecture.
- Projetos:
  - Domain
  - Application
  - Infrastructure
  - API
  - Tests
- Entidade Fornecedor:
  - Id
  - Nome_Fornecedor
  - Email_Fornecedor
  - Documento_Fornecedor
  - Status_Fornecedor (Sim ou Não)
  - CriadoEm
- CRUD completo.
- Atualize o SQLite existente, criando a tabela de fornecedores.
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
 
Importante: Não quebrar o q já existia, arquivos estratégicos, pode ser editado, mas tem q ter garantia que está tudo funcionando.

O projeto aplica separação por camadas, API documentada por OpenAPI/Swagger, persistência configurável, testes automatizados, cobertura mínima contratual de 90% e validação de segurança antes da publicação.

## 2. Ganhos entregues

- Evolução incremental sem substituir recursos existentes.
- Contratos HTTP visíveis no Swagger.
- Build, testes, cobertura e auditoria repetíveis.
- Scripts para execução local e validação.
- Estrutura preparada para hospedagem em Windows, Linux, container ou serviço .NET gerenciado.

## 3. Arquitetura

- **Domain:** entidades e regras de negócio.
- **Application:** contratos, serviços e portas de repositório.
- **Infrastructure:** Entity Framework Core, SQLite e implementações.
- **API:** controllers, injeção de dependência, Swagger e health check.
- **Tests:** testes unitários e cobertura.

## 4. Executar localmente

```powershell
./run_backend.ps1
```

Ou manualmente:

```powershell
dotnet restore
dotnet build --configuration Release
dotnet run --project src/*Api/*.csproj
```

Swagger: `http://localhost:5000/swagger` (a porta efetiva pode ser informada pelo script).
Health check: `http://localhost:5000/health`.

## 5. Testes e cobertura

```powershell
./run_tests.ps1
# ou
dotnet test --configuration Release --collect "XPlat Code Coverage"
```

A entrega só deve ser aceita com todos os testes aprovados e cobertura global acima de 90%.

## 6. Compilar/publicar para hospedagem

```powershell
dotnet publish src/*Api/*.csproj --configuration Release --output ./publish /p:UseAppHost=false
```

Envie o conteúdo de `publish` ao serviço de hospedagem. Configure a variável de ambiente `ASPNETCORE_URLS` e uma `ConnectionStrings__DefaultConnection` adequada ao ambiente. Para produção compartilhada, considere substituir SQLite por PostgreSQL ou SQL Server.

## 7. Endpoints detectados

| Método | Rota |
|---|---|
| GET | `/api/Customers` |
| GET | `/api/Customers/{id}` |
| POST | `/api/Customers` |
| PUT | `/api/Customers/{id}` |
| DELETE | `/api/Customers/{id}` |
| GET | `/api/Suppliers` |
| GET | `/api/Suppliers/{id}` |
| POST | `/api/Suppliers` |
| PUT | `/api/Suppliers/{id}` |
| DELETE | `/api/Suppliers/{id}` |

## 8. Massas de teste

### POST /api/Customers
```json
{
  "name": "Registro de teste",
  "document": "123456789",
  "email": "teste@example.com"
}
```
### POST /api/Suppliers
```json
{
  "name": "Registro de teste",
  "document": "123456789",
  "email": "teste@example.com"
}
```

## 9. Checklist de entrega

- [ ] SDK .NET compatível instalado.
- [ ] `dotnet restore` concluído.
- [ ] `dotnet build -c Release` sem erros.
- [ ] todos os testes aprovados.
- [ ] cobertura global superior a 90%.
- [ ] `/health` retorna HTTP 200.
- [ ] Swagger abre e descreve endpoints antigos e novos.
- [ ] CRUD antigo e novo testados em cópia limpa.
- [ ] secrets e connection strings configurados fora do Git.
