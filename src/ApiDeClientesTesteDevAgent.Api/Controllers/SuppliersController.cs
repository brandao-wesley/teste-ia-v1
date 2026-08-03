using Microsoft.AspNetCore.Mvc;
using ApiDeClientesTesteDevAgent.Application.Suppliers;

namespace ApiDeClientesTesteDevAgent.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class SuppliersController : ControllerBase
    {
        private readonly SupplierService _service; public SuppliersController(SupplierService service)=>_service=service;
        [HttpGet] public async Task<ActionResult<IReadOnlyList<SupplierDto>>> List(CancellationToken ct)=>Ok(await _service.ListAsync(ct));
        [HttpGet("{id:guid}")] public async Task<ActionResult<SupplierDto>> Get(Guid id,CancellationToken ct) { try { return Ok(await _service.GetByIdAsync(id,ct)); } catch(KeyNotFoundException) { return NotFound(); } }
        [HttpPost] public async Task<ActionResult<SupplierDto>> Create(CreateSupplierRequest request,CancellationToken ct) { var created=await _service.CreateAsync(request,ct); return CreatedAtAction(nameof(Get),new{id=created.Id},created); }
        [HttpPut("{id:guid}")] public async Task<ActionResult<SupplierDto>> Update(Guid id,UpdateSupplierRequest request,CancellationToken ct) { try { return Ok(await _service.UpdateAsync(id,request,ct)); } catch(KeyNotFoundException) { return NotFound(); } }
        [HttpDelete("{id:guid}")] public async Task<IActionResult> Delete(Guid id,CancellationToken ct) { try { await _service.DeleteAsync(id,ct); return NoContent(); } catch(KeyNotFoundException) { return NotFound(); } }
    }
}
