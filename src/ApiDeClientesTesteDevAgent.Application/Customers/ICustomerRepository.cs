using ApiDeClientesTesteDevAgent.Domain.Customers;

namespace ApiDeClientesTesteDevAgent.Application.Customers
{
    public interface ICustomerRepository
    {
        Task<IReadOnlyList<Customer>> ListAsync(CancellationToken cancellationToken = default);
        Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Customer customer, CancellationToken cancellationToken = default);
        void Remove(Customer customer);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
