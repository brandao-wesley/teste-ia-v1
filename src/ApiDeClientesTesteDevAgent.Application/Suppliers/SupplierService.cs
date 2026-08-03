using ApiDeClientesTesteDevAgent.Domain.Suppliers;

namespace ApiDeClientesTesteDevAgent.Application.Suppliers
{
    public sealed class SupplierService
    {
        private readonly ISupplierRepository _repository;
        public SupplierService(ISupplierRepository repository)=>_repository=repository;
        public async Task<IReadOnlyList<SupplierDto>> ListAsync(CancellationToken ct=default)=>(await _repository.ListAsync(ct)).Select(ToDto).ToList();
        public async Task<SupplierDto> GetByIdAsync(Guid id,CancellationToken ct=default)=>ToDto(await _repository.GetByIdAsync(id,ct) ?? throw new KeyNotFoundException());
        public async Task<SupplierDto> CreateAsync(CreateSupplierRequest request,CancellationToken ct=default) { var item=new Supplier(request.Name,request.Document,request.Email); await _repository.AddAsync(item,ct); await _repository.SaveChangesAsync(ct); return ToDto(item); }
        public async Task<SupplierDto> UpdateAsync(Guid id,UpdateSupplierRequest request,CancellationToken ct=default) { var item=await _repository.GetByIdAsync(id,ct) ?? throw new KeyNotFoundException(); item.Rename(request.Name); item.ChangeDocument(request.Document); item.ChangeEmail(request.Email); if(request.Active)item.Activate();else item.Deactivate(); await _repository.SaveChangesAsync(ct); return ToDto(item); }
        public async Task DeleteAsync(Guid id,CancellationToken ct=default) { var item=await _repository.GetByIdAsync(id,ct) ?? throw new KeyNotFoundException(); _repository.Remove(item); await _repository.SaveChangesAsync(ct); }
        private static SupplierDto ToDto(Supplier x)=>new(x.Id,x.Name,x.Document,x.Email,x.Active,x.CreatedAtUtc,x.UpdatedAtUtc);
    }
}
