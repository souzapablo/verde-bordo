using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerdeBordo.Application.Features.Suppliers.Commands.CreateSupplier;
using VerdeBordo.Application.Features.Suppliers.Commands.DeleteSupplier;
using VerdeBordo.Application.Features.Suppliers.Commands.UpdateSupplier;
using VerdeBordo.Application.Features.Suppliers.Queries.GetSupplierById;
using VerdeBordo.Application.Features.Suppliers.Queries.GetSuppliers;
using VerdeBordo.Application.InputModels.Suppliers;

namespace VerdeBordo.API.Controllers
{
    [ApiController]
    [Route("api/v1/suppliers")]
    public class SuppliersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SuppliersController(IMediator mediator)
        {
            _mediator = mediator;
        } 

        [HttpGet]
        public async Task<IActionResult> GetSuppliers()
        {
            var query = new GetSuppliersQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{supplierId:guid}")]
        public async Task<IActionResult> GetSupplierById(Guid supplierId)
        {
            var query = new GetSupplierByIdQuery(supplierId);

            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierInputModel input)
        {
            var command = new CreateSupplierCommand(input.Name);

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetSupplierById), new { SupplierId = id }, input);
        }

        [HttpPatch("{supplierId:guid}")]
        public async Task<IActionResult> UpdateSupplier(Guid supplierId, [FromBody] UpdateSupplierInputModel input)
        {
            var command = new UpdateSupplierCommand(supplierId, input.Name);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{supplierId:guid}")]
        public async Task<IActionResult> LogicalDeleteSupplier(Guid supplierId)
        {
            var command = new DeleteSupplierCommand(supplierId); 
            
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet("{supplierId:guid}/products")]
        public async Task<IActionResult> GetSupplierProducts(Guid productId)
        {
            return Ok();
        }

        [HttpGet("product/{productId:guid}")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            return Ok();
        }
    }
}
