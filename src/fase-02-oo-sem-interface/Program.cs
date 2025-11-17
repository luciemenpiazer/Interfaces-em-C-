using System;

namespace Fase02_OO_Sem_Interface
{
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

    public sealed class VipGerador : GeradorMensagem
    {
        public override string Gerar(string nome) 
            => $"Seja muito bem-vindo(a), {nome}. Sua experiência VIP começa agora!";
    }

    public sealed class PadraoGerador : GeradorMensagem
    {
        public override string Gerar(string nome) 
            => $"Bem-vindo(a), {nome}.";
    }

    // 3. Simulação de Uso (O Cliente)
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("--- Testando Orientação a Objetos (Fase 02) ---");

            GeradorMensagem gerador;

            // Cenário 1: Premium
            gerador = new PremiumGerador();
            Console.WriteLine($"[Premium] {gerador.Gerar("Luciemen")}");

            // Cenário 2: Admin
            gerador = new AdminGerador();
            Console.WriteLine($"[Admin]   {gerador.Gerar("Leticia")}");

            // Cenário 3: VIP (Nome diferente para variar)
            gerador = new VipGerador();
            Console.WriteLine($"[VIP]     {gerador.Gerar("Ana")}");

            // Cenário 4: Padrão (Antigo default)
            gerador = new PadraoGerador();
            Console.WriteLine($"[Padrão]  {gerador.Gerar("Visitante")}");
        }
    }
}