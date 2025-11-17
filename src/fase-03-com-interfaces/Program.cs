using System;

namespace Fase03_Com_Interfaces
{
    // 1. O CONTRATO (Interface)
    // Define a capacidade: "Eu sei gerar uma mensagem".
    public interface IGeradorMensagem
    {
        string Gerar(string nome);
    }

    // 2. IMPLEMENTAÇÕES (Peças trocáveis)
    
    public class GeradorPremium : IGeradorMensagem
    {
        public string Gerar(string nome) => $"Parabéns, {nome}, seu acesso Premium foi ativado!";
    }

    public class GeradorPadrao : IGeradorMensagem
    {
        public string Gerar(string nome) => $"Bem-vindo(a), {nome}.";
    }

    public class GeradorAdmin : IGeradorMensagem
    {
        public string Gerar(string nome) => $"Olá, Admin {nome}. Sistema pronto.";
    }

    // 3. O CLIENTE (Consumidor Desacoplado)
    // Esta classe depende do CONTRATO, não da implementação concreta.
    public class Notificador
    {
        private readonly IGeradorMensagem _gerador;

        // INJEÇÃO DE DEPENDÊNCIA (DI) pelo construtor
        public Notificador(IGeradorMensagem gerador)
        {
            _gerador = gerador;
        }

        public void NotificarUsuario(string nome)
        {
            // Polimorfismo puro: O Notificador não sabe qual peça está rodando
            string mensagem = _gerador.Gerar(nome);
            Console.WriteLine($"[Notificação]: {mensagem}");
        }
    }

    // 4. DUBLÊ DE TESTE (Stub)
    // Uma implementação falsa, rápida e previsível, usada apenas para testes.
    public class GeradorDuble : IGeradorMensagem
    {
        public string Gerar(string nome) => "MENSAGEM_DE_TESTE_FIXA";
    }

    // 5. COMPOSIÇÃO (Main)
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Fase 03: Interfaces e Injeção de Dependência ---\n");

            // Cenário A: Usuário Premium
            // Composição: Escolhemos a peça "Premium" e injetamos no Notificador
            IGeradorMensagem pecaPremium = new GeradorPremium();
            Notificador notificadorA = new Notificador(pecaPremium);
            notificadorA.NotificarUsuario("Luciemen");

            // Cenário B: Usuário Admin (Troca de peça)
            // O Notificador é o mesmo, mas o comportamento muda
            IGeradorMensagem pecaAdmin = new GeradorAdmin();
            Notificador notificadorB = new Notificador(pecaAdmin);
            notificadorB.NotificarUsuario("Leticia");

            // Cenário C: Teste com Dublê (Stub)
            // Simulando um teste onde não queremos lógica real
            Console.WriteLine("\n--- Simulando Teste Unitário ---");
            IGeradorMensagem duble = new GeradorDuble();
            Notificador notificadorTeste = new Notificador(duble);
            notificadorTeste.NotificarUsuario("QualquerNome"); 
            // Saída esperada: MENSAGEM_DE_TESTE_FIXA
        }
    }
}