using Microsoft.EntityFrameworkCore;
using ApiDeClientesTesteDevAgent.Application.Estoques;
using ApiDeClientesTesteDevAgent.Domain.Estoques;
using ApiDeClientesTesteDevAgent.Infrastructure.Persistence;

namespace ApiDeClientesTesteDevAgent.Infrastructure.Repositories
{
    public sealed class EfEstoqueRepository : IEstoqueRepository
    {
        private readonly AppDbContext _db; public EfEstoqueRepository(AppDbContext db)=>_db=db;
        public async Task<IReadOnlyList<Estoque>> ListAsync(CancellationToken ct=default)=>await _db.Set<Estoque>().AsNoTracking().OrderByDescending(x=>x.CreatedAtUtc).ToListAsync(ct);
        public Task<Estoque?> GetByIdAsync(Guid id,CancellationToken ct=default)=>_db.Set<Estoque>().FirstOrDefaultAsync(x=>x.Id==id,ct);
        public async Task AddAsync(Estoque entity,CancellationToken ct=default)=>await _db.Set<Estoque>().AddAsync(entity,ct);
        public void Remove(Estoque entity)=>_db.Set<Estoque>().Remove(entity);
        public Task SaveChangesAsync(CancellationToken ct=default)=>_db.SaveChangesAsync(ct);
    }
}
