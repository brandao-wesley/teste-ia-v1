# Plano de Rollback Git — Dev Agent

Tarefa: 22
Repositório: https://github.com/brandao-wesley/teste-ia-v1.git
Modo Git: existente_ou_novo
Branch base: feature-dev-agent-api-de-clientes-teste-dev-agent-task-20
Branch de trabalho: feature-dev-agent-api-de-fornecedores-teste-dev-agen-task-22
Branch de passagem: não usada
Commit original/estado inicial: d8613653c962b9f18821bbd8697b59e42ed7f6fa
Branch backup local: backup/dev-agent-task-22-before
Tag rollback local: rollback/dev-agent-task-22-before

## Política
- O Dev Agent não faz merge automático em dev/main/mainline.
- O Dev Agent abre Pull Request para revisão humana.
- Mesmo em repo novo, o rollback é o estado limpo/inicial antes da criação, evitando lixo.

## Se o PR ainda não foi mergeado
1. Fechar o PR.
2. Excluir a branch `feature-dev-agent-api-de-fornecedores-teste-dev-agen-task-22` se desejar.
3. Nenhuma alteração entra na branch base.

## Se o PR foi mergeado
Criar uma branch de rollback e reverter o merge commit:

```bash
git checkout feature-dev-agent-api-de-clientes-teste-dev-agent-task-20
git pull
git checkout -b rollback/dev-agent-task-22
git revert <merge_commit>
git push origin rollback/dev-agent-task-22
```

## Se precisar voltar ao estado inicial local
```bash
git checkout feature-dev-agent-api-de-clientes-teste-dev-agent-task-20
git reset --hard rollback/dev-agent-task-22-before
```

Use `push --force-with-lease` somente com aprovação explícita da engenharia.
