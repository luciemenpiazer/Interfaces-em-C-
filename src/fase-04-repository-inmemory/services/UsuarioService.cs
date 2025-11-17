using System.Collections.Generic;
using Fase04.RepositoryInMemory.Entities;
using Fase04.RepositoryInMemory.Interfaces;

namespace Fase04.RepositoryInMemory.Services
{
    public class UsuarioService
    {
        private readonly IRepository<Usuario, int> _repo;

        // O Serviço depende do contrato do repositório
        public UsuarioService(IRepository<Usuario, int> repo)
        {
            _repo = repo;
        }

        public void RegistrarUsuario(int id, string nome, string tipo)
        {
            // Aqui poderiam entrar validações (ex: nome não pode ser vazio)
            var usuario = new Usuario(id, nome, tipo);
            _repo.Add(usuario);
        }

        public IReadOnlyList<Usuario> ListarTodos()
        {
            return _repo.ListAll();
        }

        public void RemoverUsuario(int id)
        {
            _repo.Remove(id);
        }
    }
}