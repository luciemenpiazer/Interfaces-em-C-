using System;

namespace Fase04.RepositoryInMemory
{
    // --- Simulação das Classes da Fase Anterior (Interfaces e Lógica) ---
    public interface IGeradorMensagem { string Gerar(string nome); }
    public class GeradorPremium : IGeradorMensagem { public string Gerar(string n) => $"Olá PREMIUM {n}, confira ofertas exclusivas!"; }
    public class GeradorPadrao : IGeradorMensagem { public string Gerar(string n) => $"Olá {n}, assine o premium hoje!"; }
    
    public class Notificador 
    {
        private readonly IGeradorMensagem _gerador;
        public Notificador(IGeradorMensagem gerador) => _gerador = gerador;
        public void Notificar(string nome) => Console.WriteLine(_gerador.Gerar(nome));
    }
    // -------------------------------------------------------------------

    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("=== Fase 5: Repository In-Memory ===\n");

            // 1. Composição: Instanciar o Repositório e ensinar que o ID é o campo 'Id'
            // O cliente (Program) não sabe que é um Dictionary, ele só vê IRepository.
            IRepository<Usuario, int> usuarioRepo = new InMemoryRepository<Usuario, int>(u => u.Id);

            // 2. Uso: Adicionando dados (Simulando cadastro)
            Console.WriteLine("Cadastrando usuários...");
            usuarioRepo.Add(new Usuario(1, "Luciemen", "Premium"));
            usuarioRepo.Add(new Usuario(2, "João", "Padrao"));
            usuarioRepo.Add(new Usuario(3, "Maria", "Premium"));

            // 3. Lógica de Negócio: Iterar e aplicar a estratégia correta
            var usuarios = usuarioRepo.ListAll();

            foreach (var usuario in usuarios)
            {
                // Lógica da Fase 4: Decide qual "peça" usar baseada no dado do repositório
                IGeradorMensagem gerador = usuario.TipoAssinatura == "Premium" 
                    ? new GeradorPremium() 
                    : new GeradorPadrao();

                var notificador = new Notificador(gerador);
                notificador.Notificar(usuario.Nome);
            }

            // 4. Testando remoção
            Console.WriteLine("\nRemovendo usuário 2...");
            usuarioRepo.Remove(2);
            Console.WriteLine($"Total de usuários restantes: {usuarioRepo.ListAll().Count}");
        }
    }
}