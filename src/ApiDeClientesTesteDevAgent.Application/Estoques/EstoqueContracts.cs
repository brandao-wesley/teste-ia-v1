namespace ApiDeClientesTesteDevAgent.Application.Estoques
{
    public sealed record EstoqueDto(Guid Id,string Name,string Document,string Email,bool Active,DateTime CreatedAtUtc,DateTime? UpdatedAtUtc);
    public sealed record CreateEstoqueRequest(string Name,string Document,string Email);
    public sealed record UpdateEstoqueRequest(string Name,string Document,string Email,bool Active);
}
