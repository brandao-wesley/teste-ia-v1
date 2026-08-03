using Microsoft.AspNetCore.Mvc;
using ApiDeClientesTesteDevAgent.Application.Estoques;

namespace ApiDeClientesTesteDevAgent.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class EstoquesController : ControllerBase
    {
        private readonly EstoqueService _service; public EstoquesController(EstoqueService service)=>_service=service;
        [HttpGet] public async Task<ActionResult<IReadOnlyList<EstoqueDto>>> List(CancellationToken ct)=>Ok(await _service.ListAsync(ct));
        [HttpGet("{id:guid}")] public async Task<ActionResult<EstoqueDto>> Get(Guid id,CancellationToken ct) { try { return Ok(await _service.GetByIdAsync(id,ct)); } catch(KeyNotFoundException) { return NotFound(); } }
        [HttpPost] public async Task<ActionResult<EstoqueDto>> Create(CreateEstoqueRequest request,CancellationToken ct) { var created=await _service.CreateAsync(request,ct); return CreatedAtAction(nameof(Get),new{id=created.Id},created); }
        [HttpPut("{id:guid}")] public async Task<ActionResult<EstoqueDto>> Update(Guid id,UpdateEstoqueRequest request,CancellationToken ct) { try { return Ok(await _service.UpdateAsync(id,request,ct)); } catch(KeyNotFoundException) { return NotFound(); } }
        [HttpDelete("{id:guid}")] public async Task<IActionResult> Delete(Guid id,CancellationToken ct) { try { await _service.DeleteAsync(id,ct); return NoContent(); } catch(KeyNotFoundException) { return NotFound(); } }
    }
}
