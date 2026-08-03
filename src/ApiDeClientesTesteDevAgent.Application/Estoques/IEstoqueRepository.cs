using ApiDeClientesTesteDevAgent.Domain.Estoques;

namespace ApiDeClientesTesteDevAgent.Application.Estoques
{
    public interface IEstoqueRepository
    {
        Task<IReadOnlyList<Estoque>> ListAsync(CancellationToken cancellationToken=default);
        Task<Estoque?> GetByIdAsync(Guid id,CancellationToken cancellationToken=default);
        Task AddAsync(Estoque entity,CancellationToken cancellationToken=default);
        void Remove(Estoque entity);
        Task SaveChangesAsync(CancellationToken cancellationToken=default);
    }
}
