using ApiDeClientesTesteDevAgent.Application.Customers;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeClientesTesteDevAgent.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class CustomersController : ControllerBase
    {
        private readonly CustomerService _service;
        public CustomersController(CustomerService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CustomerDto>>> List(CancellationToken cancellationToken) => Ok(await _service.ListAsync(cancellationToken));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CustomerDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            try { return Ok(await _service.GetByIdAsync(id, cancellationToken)); }
            catch (KeyNotFoundException) { return NotFound(); }
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> Create(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var created = await _service.CreateAsync(request, cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CustomerDto>> Update(Guid id, UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            try { return Ok(await _service.UpdateAsync(id, request, cancellationToken)); }
            catch (KeyNotFoundException) { return NotFound(); }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try { await _service.DeleteAsync(id, cancellationToken); return NoContent(); }
            catch (KeyNotFoundException) { return NotFound(); }
        }
    }
}
