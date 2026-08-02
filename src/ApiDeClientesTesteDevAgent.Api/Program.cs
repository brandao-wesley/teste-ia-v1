using ApiDeClientesTesteDevAgent.Application.Customers;
using ApiDeClientesTesteDevAgent.Infrastructure;
using ApiDeClientesTesteDevAgent.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.EnsureCreatedAsync();
}
app.MapControllers();

// Fabulosoft v5.65 root endpoint contract
app.MapGet("/", () => Results.Redirect("/swagger"))
   .WithName("Root")
   .WithSummary("Redireciona a raiz da API para o Swagger para evitar 404 ao abrir o projeto no navegador.");

app.MapGet("/api", () => Results.Ok(new
{
    name = "ApiDeClientesTesteDevAgent",
    status = "running",
    documentation = "/swagger",
    health = "/health",
    customers = "/api/customers"
}))
   .WithName("ApiInfo")
   .WithSummary("Informações rápidas da API e principais rotas.");

app.MapGet("/health", () => Results.Ok(new { status = "ok", app = "ApiDeClientesTesteDevAgent" }));
app.Run();

public partial class Program { }
