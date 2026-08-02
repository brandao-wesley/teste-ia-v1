namespace ApiDeClientesTesteDevAgent.Application.Customers
{
    public sealed record CustomerDto(Guid Id, string Name, string Email, string Phone, bool Active, DateTime CreatedAtUtc, DateTime? UpdatedAtUtc);
    public sealed record CreateCustomerRequest(string Name, string Email, string Phone);
    public sealed record UpdateCustomerRequest(string Name, string Email, string Phone, bool Active);
}
