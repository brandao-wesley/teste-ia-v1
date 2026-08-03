using ApiDeClientesTesteDevAgent.Domain.Suppliers;

namespace ApiDeClientesTesteDevAgent.Application.Suppliers
{
    public interface ISupplierRepository
    {
        Task<IReadOnlyList<Supplier>> ListAsync(CancellationToken cancellationToken=default);
        Task<Supplier?> GetByIdAsync(Guid id,CancellationToken cancellationToken=default);
        Task AddAsync(Supplier entity,CancellationToken cancellationToken=default);
        void Remove(Supplier entity);
        Task SaveChangesAsync(CancellationToken cancellationToken=default);
    }
}
