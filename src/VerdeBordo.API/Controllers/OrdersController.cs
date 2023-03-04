using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VerdeBordo.Application.Features.Embroideries.Commands;
using VerdeBordo.Application.Features.Orders.Commands.CreateOrder;
using VerdeBordo.Application.Features.Orders.Queries.GetOrderById;
using VerdeBordo.Application.Features.Orders.Queries.GetOrders;
using VerdeBordo.Application.InputModels.Embroideries;
using VerdeBordo.Application.InputModels.Orders;
using VerdeBordo.Core.Enums;

namespace VerdeBordo.API.Controllers;

[ApiController]
[Route("api/v1/orders")]
[Authorize]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var query = new GetOrdersQuery();

        return Ok(await _mediator.Send(query));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOrderById(Guid id)
    {
        var query = new GetOrderByIdQuery(id);

        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderInputModel input)
    {
        var command = new CreateOrderCommand(input.CustomerId, input.DueDate, input.PaymentMethod);

        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetOrderById), new { Id = id }, input);
    }

    [HttpPost("{id:guid}/embroideiry")]
    public async Task<IActionResult> CreateEmbroideiry(Guid id, [FromBody] CreateEmbroideryInputModel input)
    {
        var command = new CreateEmbroideryCommand(
            id, 
            input.Description, 
            input.Details, 
            input.Size, 
            input.Price, 
            input.HasFrame);

        var orderId = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetOrderById), new { Id = orderId }, input);
    }
}