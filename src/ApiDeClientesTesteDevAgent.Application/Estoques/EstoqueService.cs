using ApiDeClientesTesteDevAgent.Domain.Estoques;

namespace ApiDeClientesTesteDevAgent.Application.Estoques
{
    public sealed class EstoqueService
    {
        private readonly IEstoqueRepository _repository;
        public EstoqueService(IEstoqueRepository repository)=>_repository=repository;
        public async Task<IReadOnlyList<EstoqueDto>> ListAsync(CancellationToken ct=default)=>(await _repository.ListAsync(ct)).Select(ToDto).ToList();
        public async Task<EstoqueDto> GetByIdAsync(Guid id,CancellationToken ct=default)=>ToDto(await _repository.GetByIdAsync(id,ct) ?? throw new KeyNotFoundException());
        public async Task<EstoqueDto> CreateAsync(CreateEstoqueRequest request,CancellationToken ct=default) { var item=new Estoque(request.Name,request.Document,request.Email); await _repository.AddAsync(item,ct); await _repository.SaveChangesAsync(ct); return ToDto(item); }
        public async Task<EstoqueDto> UpdateAsync(Guid id,UpdateEstoqueRequest request,CancellationToken ct=default) { var item=await _repository.GetByIdAsync(id,ct) ?? throw new KeyNotFoundException(); item.Rename(request.Name); item.ChangeDocument(request.Document); item.ChangeEmail(request.Email); if(request.Active)item.Activate();else item.Deactivate(); await _repository.SaveChangesAsync(ct); return ToDto(item); }
        public async Task DeleteAsync(Guid id,CancellationToken ct=default) { var item=await _repository.GetByIdAsync(id,ct) ?? throw new KeyNotFoundException(); _repository.Remove(item); await _repository.SaveChangesAsync(ct); }
        private static EstoqueDto ToDto(Estoque x)=>new(x.Id,x.Name,x.Document,x.Email,x.Active,x.CreatedAtUtc,x.UpdatedAtUtc);
    }
}
