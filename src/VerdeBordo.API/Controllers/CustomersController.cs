using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerdeBordo.Application.Features.Customers.Queries.GetCustomers;

namespace VerdeBordo.API.Controllers;

[ApiController]
[Route("api/v1/customers")]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        var query = new GetCustomersQuery();

        return base.Ok(await _mediator.Send(query));
    }
}
