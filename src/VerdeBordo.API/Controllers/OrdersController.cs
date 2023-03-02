using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VerdeBordo.Application.Features.Orders.Queries.GetOrders;

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
}