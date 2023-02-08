using Microsoft.AspNetCore.Mvc;

namespace VerdeBordo.API.Controllers
{
    [ApiController]
    [Route("api/v1/suppliers")]
    public class SuppliersController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSuppliers()
        {
            return Ok();
        }

        [HttpGet("{supplierId:guid}")]
        public async Task<IActionResult> GetSupplierById(Guid supplierId)
        {
            return Ok();
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
