using System;
using Fase04.RepositoryInMemory.Interfaces;

namespace Fase04.RepositoryInMemory.Services
{
    public class Notificador
    {
        private readonly IGeradorMensagem _gerador;

        public Notificador(IGeradorMensagem gerador)
        {
            _gerador = gerador;
        }

        public void Notificar(string nome)
        {
            // Delega a criação da mensagem para a estratégia injetada
            string mensagem = _gerador.Gerar(nome);
            Console.WriteLine($"[Notificação] {mensagem}");
        }
    }
}