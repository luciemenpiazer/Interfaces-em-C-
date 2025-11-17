using Fase04.RepositoryInMemory.Interfaces;

namespace Fase04.RepositoryInMemory.Services
{
    public class GeradorPremium : IGeradorMensagem
    {
        public string Gerar(string n) => $"Olá PREMIUM {n}, confira ofertas exclusivas!";
    }

    public class GeradorPadrao : IGeradorMensagem
    {
        public string Gerar(string n) => $"Olá {n}, assine o premium hoje!";
    }
}