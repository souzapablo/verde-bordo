using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerdeBordo.Application.Features.Suppliers.Queries.GetSupplierById;
using VerdeBordo.Application.Features.Suppliers.Queries.GetSuppliers;

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
        public async Task<IActionResult> CreateSupplier()
        {
            return Ok();
        }

        [HttpPatch("{supplierId:guid}")]
        public async Task<IActionResult> UpdateSupplier(Guid supplierId)
        {
            return Ok();
        }

        [HttpDelete("{supplierId:guid}")]
        public async Task<IActionResult> DeleteSupplier(Guid supplierId)
        {
            return NoContent();
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
