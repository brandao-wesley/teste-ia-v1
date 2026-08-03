namespace ApiDeClientesTesteDevAgent.Application.Suppliers
{
    public sealed record SupplierDto(Guid Id,string Name,string Document,string Email,bool Active,DateTime CreatedAtUtc,DateTime? UpdatedAtUtc);
    public sealed record CreateSupplierRequest(string Name,string Document,string Email);
    public sealed record UpdateSupplierRequest(string Name,string Document,string Email,bool Active);
}
