namespace Fase04.RepositoryInMemory
{
    // Record: ideal para dados imutáveis (ID, Nome, Tipo)
    public sealed record Usuario(int Id, string Nome, string TipoAssinatura);
}