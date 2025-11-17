using System;

public class Program
{
    // Função Central (Procedural)
    // Melhoria: Uso de "Expression Body" (=>) e "Switch Expression"
    public static string GerarMensagemProcedural(string tipoUsuario, string nome)
    {
        // A decisão continua centralizada aqui (acoplamento), 
        // mas com sintaxe moderna e segura contra nulos.
        return (tipoUsuario?.ToLowerInvariant()) switch
        {
            "premium" => $"Parabéns, {nome}, seu acesso Premium foi ativado!",
            
            "admin"   => $"Olá, Admin {nome}. Pronta para gerenciar o sistema?",
            
            "vip"     => $"Seja muito bem-vindo(a), {nome}. Sua experiência VIP começa agora!",
            
            // O underscore (_) representa o 'default' no switch expression
            _         => $"Bem-vindo(a), {nome}."
        };
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("--- Testando Função Procedural (Fase 01) ---");

        // Cenário 1: Premium
        Console.WriteLine($"[Premium] {GerarMensagemProcedural("premium", "Luciemen")}");

        // Cenário 2: Admin (Case Insensitive)
        Console.WriteLine($"[Admin]   {GerarMensagemProcedural("AdMiN", "Leticia")}");

        // Cenário 3: VIP
        Console.WriteLine($"[VIP]     {GerarMensagemProcedural("vip", "Ana")}");

        // Cenário 4: Padrão
        Console.WriteLine($"[Padrão]  {GerarMensagemProcedural("padrao", "Convidado")}");

        // Cenário 5: Inválido (Cai no default)
        Console.WriteLine($"[Inválido]{GerarMensagemProcedural("desconhecido", "Visitante")}");
        
        // Cenário 6: Nulo (Teste de Robustez - Novo)
        Console.WriteLine($"[Null]    {GerarMensagemProcedural(null, "Fantasma")}");
    }
}