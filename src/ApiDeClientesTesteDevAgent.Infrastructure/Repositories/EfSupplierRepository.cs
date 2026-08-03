using Microsoft.EntityFrameworkCore;
using ApiDeClientesTesteDevAgent.Application.Suppliers;
using ApiDeClientesTesteDevAgent.Domain.Suppliers;
using ApiDeClientesTesteDevAgent.Infrastructure.Persistence;

namespace ApiDeClientesTesteDevAgent.Infrastructure.Repositories
{
    public sealed class EfSupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _db; public EfSupplierRepository(AppDbContext db)=>_db=db;
        public async Task<IReadOnlyList<Supplier>> ListAsync(CancellationToken ct=default)=>await _db.Set<Supplier>().AsNoTracking().OrderByDescending(x=>x.CreatedAtUtc).ToListAsync(ct);
        public Task<Supplier?> GetByIdAsync(Guid id,CancellationToken ct=default)=>_db.Set<Supplier>().FirstOrDefaultAsync(x=>x.Id==id,ct);
        public async Task AddAsync(Supplier entity,CancellationToken ct=default)=>await _db.Set<Supplier>().AddAsync(entity,ct);
        public void Remove(Supplier entity)=>_db.Set<Supplier>().Remove(entity);
        public Task SaveChangesAsync(CancellationToken ct=default)=>_db.SaveChangesAsync(ct);
    }
}
