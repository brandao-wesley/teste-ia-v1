using Microsoft.EntityFrameworkCore;
using ApiDeClientesTesteDevAgent.Application.Customers;
using ApiDeClientesTesteDevAgent.Domain.Customers;
using ApiDeClientesTesteDevAgent.Infrastructure.Persistence;

namespace ApiDeClientesTesteDevAgent.Infrastructure.Repositories
{
    public sealed class EfCustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _db;
        public EfCustomerRepository(AppDbContext db) => _db = db;
        public async Task<IReadOnlyList<Customer>> ListAsync(CancellationToken cancellationToken = default) => await _db.Customers.AsNoTracking().OrderByDescending(x => x.CreatedAtUtc).ToListAsync(cancellationToken);
        public Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) => _db.Customers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        public async Task AddAsync(Customer customer, CancellationToken cancellationToken = default) => await _db.Customers.AddAsync(customer, cancellationToken);
        public void Remove(Customer customer) => _db.Customers.Remove(customer);
        public Task SaveChangesAsync(CancellationToken cancellationToken = default) => _db.SaveChangesAsync(cancellationToken);
    }
}
