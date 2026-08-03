using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApiDeClientesTesteDevAgent.Application.Customers;
using ApiDeClientesTesteDevAgent.Application.Estoques;
using ApiDeClientesTesteDevAgent.Application.Suppliers;
using ApiDeClientesTesteDevAgent.Infrastructure.Persistence;
using ApiDeClientesTesteDevAgent.Infrastructure.Repositories;

namespace ApiDeClientesTesteDevAgent.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection") ?? "Data Source=fabulosoft-app.db";
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(connection));
            services.AddScoped<ICustomerRepository, EfCustomerRepository>();
        services.AddScoped<IEstoqueRepository, EfEstoqueRepository>();
        services.AddScoped<ISupplierRepository, EfSupplierRepository>();
            return services;
        }
    }
}
