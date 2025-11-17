using Xunit;
using Fase04.RepositoryInMemory; // Certifique-se que o "dotnet add reference" foi feito
using System.Linq;

namespace Fase04.Tests
{
    public class UsuarioRepositoryTests
    {
        // Helper para criar o repositório limpo a cada teste
        private IRepository<Usuario, int> CriarRepo() 
            => new InMemoryRepository<Usuario, int>(u => u.Id);

        [Fact]
        public void Add_Deve_Inserir_Usuario()
        {
            var repo = CriarRepo();
            repo.Add(new Usuario(1, "Teste", "Padrao"));

            var lista = repo.ListAll();
            Assert.Single(lista);
            Assert.Equal("Teste", lista.First().Nome);
        }

        [Fact]
        public void GetById_Deve_Retornar_Correto()
        {
            var repo = CriarRepo();
            repo.Add(new Usuario(10, "Alvo", "Premium"));

            var resultado = repo.GetById(10);
            Assert.NotNull(resultado);
            Assert.Equal("Alvo", resultado!.Nome);
        }

        [Fact]
        public void Remove_Deve_Eliminar_Item()
        {
            var repo = CriarRepo();
            repo.Add(new Usuario(5, "Remover", "Padrao"));

            var sucesso = repo.Remove(5);
            Assert.True(sucesso);
            Assert.Empty(repo.ListAll());
        }
    }
}