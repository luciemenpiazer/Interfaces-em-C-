# Fase 02: Procedural Mínimo (Geração de Mensagens)

Esta fase implementa uma lógica simples (geração de mensagens) usando uma abordagem procedural, centralizada em uma única função.

## Implementação (C# Procedural)

A implementação procedural centraliza a lógica de decisão dentro de uma única função (`GerarMensagemProcedural`). [cite_start]Ela recebe o tipo de usuário como uma string e usa uma estrutura `switch` para determinar a saída[cite: 209].

```csharp
// Função Central (Procedural)
public static string GerarMensagemProcedural(string tipoUsuario, string nome)
{
    // A decisão é centralizada aqui: o ponto de acoplamento
    switch (tipoUsuario.ToLower()) 
    {
        case "premium":
            return $"Parabéns, {nome}, seu acesso Premium foi ativado!";
            
        case "admin":
            return $"Olá, Admin {nome}. Pronta para gerenciar o sistema?";
            
        case "vip":
            return $"Seja muito bem-vindo(a), {nome}. Sua experiência VIP começa agora!";

        // Caso Padrão/Default
        default: 
            return $"Bem-vindo(a), {nome}.";
    }
}