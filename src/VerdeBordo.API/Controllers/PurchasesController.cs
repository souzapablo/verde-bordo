using Microsoft.AspNetCore.Mvc;

namespace VerdeBordo.API.Controllers;

[ApiController]
[Route("api/v1/purchases")]
public class PurchasesController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPurchases()
    {
        return Ok();
    }

    [HttpGet("{purchaseId:guid}")]
    public async Task<IActionResult> GetPurchaseById(Guid purchaseId)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreatePurchase()
    {
        return Ok();
    }

    [HttpPatch("{purchaseId:guid}")]
    public async Task<IActionResult> UpdatePurchase(Guid purchaseId)
    {
        return Ok();
    }

    [HttpDelete("{purchaseId:guid}")]
    public async Task<IActionResult> DeletePurchase(Guid purchaseId)
    {
        return NoContent();
    }

    [HttpPost("report")]
    public async Task<IActionResult> GenerateReport()
    {
        return Ok();
    }
}
