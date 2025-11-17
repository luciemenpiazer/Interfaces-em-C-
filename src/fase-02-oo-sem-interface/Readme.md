# Fase 02: Orientação a Objetos (Geração de Mensagens)

Nesta fase, a solução evoluiu de uma abordagem puramente procedural para uma estrutura baseada nos pilares da Orientação a Objetos. [cite\_start]O objetivo principal foi substituir a estrutura condicional centralizada (`switch/case`) por **polimorfismo de herança**[cite: 951].

## 1\. O que mudou (Procedural $\to$ OO)

### Antes: Abordagem Procedural (Fase 01)

Na fase anterior, a decisão residia em uma única função que verificava uma string ("premium", "admin", etc.). [cite\_start]Isso criava um ponto de acoplamento centralizado, onde qualquer novo tipo exigia a edição do arquivo principal[cite: 113, 114].

```csharp
// Como era na Fase 01: Lógica centralizada e rígida
public static string GerarMensagemProcedural(string tipoUsuario, string nome)
{
    switch (tipoUsuario.ToLower()) 
    {
        case "premium":
            return $"Parabéns, {nome}, seu acesso Premium foi ativado!";
        case "admin":
            return $"Olá, Admin {nome}. Pronta para gerenciar o sistema?";
        case "vip":
            return $"Seja muito bem-vindo(a), {nome}. Sua experiência VIP começa agora!";
        default: 
            return $"Bem-vindo(a), {nome}.";
    }
}
```

### Agora: Abordagem Orientada a Objetos (Fase 02)

A lógica de decisão foi dissolvida. Cada "modo" tornou-se uma classe autônoma. [cite\_start]O cliente não interage mais com strings para decidir o comportamento, mas sim instancia o objeto específico que deseja [cite: 131-134].

```csharp
// 1. Classe Base Abstrata (Contrato)
public abstract class GeradorMensagem
{
    public abstract string Gerar(string nome);
}

// 2. Classes Concretas (Especializações)
public sealed class PremiumGerador : GeradorMensagem
{
    public override string Gerar(string nome) 
        => $"Parabéns, {nome}, seu acesso Premium foi ativado!";
}

public sealed class AdminGerador : GeradorMensagem
{
    public override string Gerar(string nome) 
        => $"Olá, Admin {nome}. Pronta para gerenciar o sistema?";
}

// ... outras classes (VipGerador, PadraoGerador)
```

## 2\. O que foi aplicado

Conceitos técnicos utilizados para realizar essa refatoração:

  * [cite\_start]**Classe Base Abstrata (`abstract class`):** Define o contrato comum `Gerar(string nome)`[cite: 135].
  * **Classes Concretas (`sealed class`):** Especializam o comportamento. [cite\_start]O uso de `sealed` indica que são classes "folha" (sem herdeiros), permitindo otimizações[cite: 94].
  * **Polimorfismo:** O sistema trata todos os geradores como `GeradorMensagem`, sem precisar conhecer a implementação específica durante a execução.

## 3\. Análise de Design: Melhorias e Rigidez

[cite\_start]Conforme a análise heurística do projeto[cite: 952], observamos as seguintes trocas:

  * **O que melhorou:**

      * **Alta Coesão:** Cada classe geradora tem apenas uma responsabilidade (gerar sua própria mensagem).
      * [cite\_start]**Extensibilidade (OCP):** Para criar um novo perfil (ex: "SuperAdmin"), basta criar uma nova classe, sem risco de quebrar a lógica dos perfis existentes ou alterar um `switch` gigante[cite: 496].

  * **O que ficou rígido (Limitações):**

      * **Acoplamento por Herança:** As classes concretas são forçadas a herdar de `GeradorMensagem`. Como C\# não suporta herança múltipla, essas classes não podem herdar comportamento de outros lugares.
      * [cite\_start]**Instanciação no Cliente:** O código cliente (`Program.cs`) ainda precisa conhecer as classes concretas para dar o `new` (ex: `new PremiumGerador()`), mantendo um acoplamento que será resolvido na próxima fase com Interfaces[cite: 149].

## 4\. Como Executar

A partir da raiz do repositório, navegue até a pasta da fase e execute:

```bash
cd src/fase-02-oo-sem-interface
dotnet run
```