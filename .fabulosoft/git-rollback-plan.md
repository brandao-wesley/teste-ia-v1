# Plano de Rollback Git — Dev Agent

Tarefa: 23
Repositório: https://github.com/brandao-wesley/teste-ia-v1.git
Modo Git: existente_ou_novo
Branch base: feature-dev-agent-api-de-fornecedores-teste-dev-agen-task-22
Branch de trabalho: feature-dev-agent-api-de-estoque-teste-dev-agent-task-23
Branch de passagem: não usada
Commit original/estado inicial: 2cc61984f3dfb0626888812d79a364e6f63cb918
Branch backup local: backup/dev-agent-task-23-before
Tag rollback local: rollback/dev-agent-task-23-before

## Política
- O Dev Agent não faz merge automático em dev/main/mainline.
- O Dev Agent abre Pull Request para revisão humana.
- Mesmo em repo novo, o rollback é o estado limpo/inicial antes da criação, evitando lixo.

## Se o PR ainda não foi mergeado
1. Fechar o PR.
2. Excluir a branch `feature-dev-agent-api-de-estoque-teste-dev-agent-task-23` se desejar.
3. Nenhuma alteração entra na branch base.

## Se o PR foi mergeado
Criar uma branch de rollback e reverter o merge commit:

```bash
git checkout feature-dev-agent-api-de-fornecedores-teste-dev-agen-task-22
git pull
git checkout -b rollback/dev-agent-task-23
git revert <merge_commit>
git push origin rollback/dev-agent-task-23
```

## Se precisar voltar ao estado inicial local
```bash
git checkout feature-dev-agent-api-de-fornecedores-teste-dev-agen-task-22
git reset --hard rollback/dev-agent-task-23-before
```

Use `push --force-with-lease` somente com aprovação explícita da engenharia.
