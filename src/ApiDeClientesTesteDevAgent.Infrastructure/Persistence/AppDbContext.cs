using Microsoft.EntityFrameworkCore;
using ApiDeClientesTesteDevAgent.Domain.Estoques;
using ApiDeClientesTesteDevAgent.Domain.Suppliers;
using ApiDeClientesTesteDevAgent.Domain.Customers;

namespace ApiDeClientesTesteDevAgent.Infrastructure.Persistence
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Estoque> Estoques => Set<Estoque>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<Customer> Customers => Set<Customer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).HasMaxLength(160).IsRequired();
                builder.Property(x => x.Email).HasMaxLength(220);
                builder.Property(x => x.Phone).HasMaxLength(40);
                builder.Property(x => x.Active).IsRequired();
            });
        }
    }
}
