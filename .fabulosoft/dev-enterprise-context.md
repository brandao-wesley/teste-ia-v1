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
