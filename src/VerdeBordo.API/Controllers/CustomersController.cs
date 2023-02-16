using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerdeBordo.Application.Features.Customers.Commands;
using VerdeBordo.Application.Features.Customers.Queries.GetById;
using VerdeBordo.Application.Features.Customers.Queries.GetCustomers;
using VerdeBordo.Application.InputModels.Customers;

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

        return Ok(await _mediator.Send(query));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCustomerById(Guid id)
    {
        var query = new GetCustomerByIdQuery(id);

        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CreateCustomerInputModel input)
    {
        var command = new CreateCustomerCommand(input.Name, input.Contact);

        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetCustomerById), new { Id = id }, input);
    }

}
