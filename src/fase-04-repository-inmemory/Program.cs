using System;
using Fase04.RepositoryInMemory.Entities;
using Fase04.RepositoryInMemory.Interfaces;
using Fase04.RepositoryInMemory.Repositories;
using Fase04.RepositoryInMemory.Services;

namespace Fase04.RepositoryInMemory
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("=== Fase 5: Repository + Service ===\n");

            // 1. COMPOSIÇÃO (Setup)
            // Instancia o Repositório (Dados)
            IRepository<Usuario, int> repo = new InMemoryRepository<Usuario, int>(u => u.Id);
            
            // Instancia o Service (Regras), injetando o Repositório nele
            UsuarioService usuarioService = new UsuarioService(repo);

            // 2. EXECUÇÃO (Uso do Service)
            Console.WriteLine("--- Cadastrando via Service ---");
            usuarioService.RegistrarUsuario(1, "Luciemen", "Premium");
            usuarioService.RegistrarUsuario(2, "João", "Padrao");
            usuarioService.RegistrarUsuario(3, "Maria", "Premium");

            // 3. CONSUMO (Iteração)
            var todos = usuarioService.ListarTodos();

            foreach (var usuario in todos)
            {
                // Lógica de apresentação/notificação (Fase 4)
                IGeradorMensagem gerador = usuario.TipoAssinatura == "Premium" 
                    ? new GeradorPremium() 
                    : new GeradorPadrao();

                var notificador = new Notificador(gerador);
                notificador.Notificar(usuario.Nome);
            }

            // 4. REMOÇÃO
            usuarioService.RemoverUsuario(2);
            Console.WriteLine($"\nTotal após remoção: {usuarioService.ListarTodos().Count}");
        }
    }
}