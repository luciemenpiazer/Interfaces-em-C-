# Tarefa por Fases - Interfaces em C#

Este repositório documenta a evolução de um projeto, fase por fase, aplicando conceitos de design de software em C#.

## 🎯 Objetivo Geral
Consolidar a jornada procedural → OO → interfaces e repository, com foco em **design consciente** (ISP, baixo acoplamento, testabilidade).

## 👥 Equipe
| Nome | RA |
| --- | --- |
| Leticia Moro | 2602008 |
| Luciemen Piazer | 2652609 |

---

## 🗺️ Sumário de Fases
Abaixo estão os links para a documentação e para o código-fonte de cada etapa:

* [Fase 00: Aquecimento Conceitual](#fase-00) | 📂 [Código Fonte](./src/fase-00-aquecimento/)
* [Fase 01: Procedural](#fase-01) | 📂 [Código Fonte](./src/fase-01-procedural/)
* [Fase 02: OO Sem Interface](#fase-02) | 📂 [Código Fonte](./src/fase-02-oo-sem-interface/)
* [Fase 03: OO Com Interface](#fase-03) | 📂 [Código Fonte](./src/fase-03-com-interfaces/)

---

### <a id="fase-00"></a> 🔥 Fase 00: Aquecimento Conceitual
**Foco:** Entender contratos de capacidade sem código.

#### 💡 Decisões de Design
* Definição de cenários do cotidiano onde o objetivo é fixo mas as "peças" variam.
* **Cenário 1 (Pagamento):** O contrato é "Pagar", as implementações são "Pix", "Cartão" ou "Boleto".
* **Cenário 2 (Entrega):** O contrato é "Entregar Relatório", as peças são "PDF por E-mail" ou "CSV no Disco".

---

### <a id="fase-01"></a> 🔨 Fase 01: Procedural
**Foco:** Implementação de lógica centralizada com `switch`.

#### 💡 Decisões de Design
* Uso de `Switch Expressions` (C# 8) para mapear tipos de usuário.
* Identificação do **acoplamento**: toda a regra de negócio reside em um único método estático.

#### ✅ Checklist de Qualidade
* [x] Código funcional.
* [x] Identificação clara de onde o princípio OCP (Aberto/Fechado) é violado.

---

### <a id="fase-02"></a> 🧱 Fase 02: OO Sem Interface
**Foco:** Substituição de condicional por polimorfismo (Herança).

#### 💡 Decisões de Design
* **Remoção de Condicionais:** O `switch` foi removido; a lógica agora pertence a classes concretas (`PremiumGerador`, `AdminGerador`).
* **Herança:** Uso de classe base abstrata `GeradorMensagem` para definir o contrato.
* **Rigidez:** Percebemos que o cliente ainda precisa dar `new ClasseConcreta()`, mantendo acoplamento.

#### ✅ Checklist de Qualidade
* [x] Switch removido da regra de negócio.
* [x] Alta coesão (cada classe faz apenas uma coisa).
* [x] Classes folhas marcadas como `sealed`.

#### 📸 Evidências de Testes
Abaixo, o log de execução comprovando o comportamento polimórfico. Observe que não passamos mais uma string de "tipo", mas sim instanciamos classes diferentes que respondem ao mesmo método `.Gerar()`:

```text
--- Testando Orientação a Objetos (Fase 02) ---
[Premium] Parabéns, Luciemen, seu acesso Premium foi ativado!
[Admin]   Olá, Admin Leticia. Pronta para gerenciar o sistema?
[VIP]     Seja muito bem-vindo(a), Ana. Sua experiência VIP começa agora!
[Padrão]  Bem-vindo(a), Visitante.
```

---

### <a id="fase-03"></a> 🔌 Fase 03: Interfaces e DI
**Foco:** Desacoplamento total usando Contratos (`interface`) e Injeção de Dependência.

#### 💡 Decisões de Design
* **Inversão de Controle:** O `Notificador` não cria mais instâncias (`new`), ele as recebe no construtor.
* **Testabilidade:** Criação de um `GeradorDuble` (Stub) para validar o fluxo sem depender de lógica de negócio real.
* **Contrato:** A interface `IGeradorMensagem` define o "o quê", enquanto as classes definem o "como".

#### ✅ Checklist de Qualidade
* [x] Cliente (`Notificador`) não depende de classes concretas.
* [x] Possibilidade de trocar a implementação sem alterar o cliente.
* [x] Teste com dublê executado com sucesso.

#### 📸 Evidências de Testes
```text
--- Fase 03: Interfaces e Injeção de Dependência ---
[Notificação]: Parabéns, Luciemen, seu acesso Premium foi ativado!
[Notificação]: Olá, Admin Leticia. Sistema pronto.
```

---

