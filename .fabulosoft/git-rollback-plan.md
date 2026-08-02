# Plano de Rollback Git — Dev Agent

Tarefa: 20
Repositório: https://github.com/brandao-wesley/teste-ia-v1.git
Modo Git: existente_ou_novo
Branch base: main
Branch de trabalho: feature-dev-agent-api-de-clientes-teste-dev-agent-task-20
Branch de passagem: não usada
Commit original/estado inicial: 27dcc4236575db89c8f5864514f04a954a22887a
Branch backup local: backup/dev-agent-task-20-before
Tag rollback local: rollback/dev-agent-task-20-before

## Política
- O Dev Agent não faz merge automático em dev/main/mainline.
- O Dev Agent abre Pull Request para revisão humana.
- Mesmo em repo novo, o rollback é o estado limpo/inicial antes da criação, evitando lixo.

## Se o PR ainda não foi mergeado
1. Fechar o PR.
2. Excluir a branch `feature-dev-agent-api-de-clientes-teste-dev-agent-task-20` se desejar.
3. Nenhuma alteração entra na branch base.

## Se o PR foi mergeado
Criar uma branch de rollback e reverter o merge commit:

```bash
git checkout main
git pull
git checkout -b rollback/dev-agent-task-20
git revert <merge_commit>
git push origin rollback/dev-agent-task-20
```

## Se precisar voltar ao estado inicial local
```bash
git checkout main
git reset --hard rollback/dev-agent-task-20-before
```

Use `push --force-with-lease` somente com aprovação explícita da engenharia.
