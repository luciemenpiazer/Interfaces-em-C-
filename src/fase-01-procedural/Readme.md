# Fase 1: Heurística Antes do Código (Mapa Mental)

**Problema Trivial Escolhido:** Geração de Mensagens de Boas-Vindas

**Objetivo:** O sistema precisa gerar uma mensagem de boas-vindas padronizada, mas que se adapte a diferentes tipos de usuários (Ex: Usuário Padrão, Usuário Premium, Administrador).

---

## 1. Versão Procedural

**Como funciona:** Uma função central é responsável por gerar a mensagem.

**Sintaxe (Mental):**
```plaintext
FUNCAO GerarMensagem(TipoDeUsuario, Nome)
    SE TipoDeUsuario for "Padrao"
        Retorna "Bem-vindo(a), [Nome]."
    SENÃO SE TipoDeUsuario for "Premium"
        Retorna "Parabéns, [Nome], seu acesso Premium foi ativado!"
    SENÃO SE TipoDeUsuario for "Admin"
        Retorna "Olá, Admin [Nome]. Pronta para gerenciar?"
    SENÃO
        Retorna "Acesso negado."