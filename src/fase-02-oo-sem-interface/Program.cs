using System;

public class Program
{
    // O "Fluxo" - A função procedural centralizada
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

            // Caso Padrão/Default (inclui "padrao", "desconhecido", etc.)
            default: 
                return $"Bem-vindo(a), {nome}.";
        }
    }

    // Main para executar e testar a função
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Testando Função Procedural ---");

        // Cenário 1: Premium
        string msg1 = GerarMensagemProcedural("premium", "Luciemen");
        Console.WriteLine($"Teste Premium: {msg1}");

        // Cenário 2: Admin (Case Insensitive)
        string msg2 = GerarMensagemProcedural("AdMiN", "Leticia");
        Console.WriteLine($"Teste Admin: {msg2}");

        // Cenário 3: VIP
        string msg3 = GerarMensagemProcedural("vip", "Ana");
        Console.WriteLine($"Teste VIP: {msg3}");

        // Cenário 4: Padrão (Default)
        string msg4 = GerarMensagemProcedural("padrao", "Convidado");
        Console.WriteLine($"Teste Padrão: {msg4}");

        // Cenário 5: Inválido (Default)
        string msg5 = GerarMensagemProcedural("desconhecido", "Visitante");
        Console.WriteLine($"Teste Inválido: {msg5}");
    }
}