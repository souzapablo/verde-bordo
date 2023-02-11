using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerdeBordo.Application.Features.Purchases.Commands.CreatePurchase;
using VerdeBordo.Application.Features.Purchases.Commands.DeletePurchase;
using VerdeBordo.Application.Features.Purchases.Commands.UpdatePurchase;
using VerdeBordo.Application.Features.Purchases.Queries.GetPurchaseById;
using VerdeBordo.Application.Features.Purchases.Queries.GetPurchases;
using VerdeBordo.Application.InputModels.Purchases;

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
        var query = new GetPurchaseByIdQuery(purchaseId);

        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> CreatePurchase(CreatePurchaseInputModel input)
    {
        var command = new CreatePurchaseCommand(input.ProductId, input.AmountPurchased, input.PurchaseDate, input.Shipment);
        
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetPurchaseById), new { PurchaseId = id }, input);
    }

    [HttpPatch("{purchaseId:guid}")]
    public async Task<IActionResult> UpdatePurchase(Guid purchaseId, UpdatePurchaseInputModel input)
    {
        var command = new UpdatePurchaseCommand(purchaseId, input.NewPurchasedAmount, input.NewShipment, input.NewPurchaseDate);

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{purchaseId:guid}")]
    public async Task<IActionResult> DeletePurchase(Guid purchaseId)
    {
        var command = new DeletePurchaseCommand(purchaseId);

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPost("report")]
    public async Task<IActionResult> GenerateReport()
    {
        return Ok();
    }
}
