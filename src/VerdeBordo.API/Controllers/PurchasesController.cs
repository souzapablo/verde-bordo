using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerdeBordo.Application.Features.Purchases.Queries.GetPurchases;

namespace VerdeBordo.API.Controllers;

[ApiController]
[Route("api/v1/purchases")]
public class PurchasesController : ControllerBase
{
    private readonly IMediator _mediator;

    public PurchasesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetPurchases()
    {
        var query = new GetPurchasesQuery();
        
        return Ok(await _mediator.Send(query));
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
