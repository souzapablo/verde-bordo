using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerdeBordo.Application.Features.Customers.Commands.CreateCustomer;
using VerdeBordo.Application.Features.Customers.Commands.DeleteCustomer;
using VerdeBordo.Application.Features.Customers.Commands.UpdateCustomer;
using VerdeBordo.Application.Features.Customers.Queries.GetById;
using VerdeBordo.Application.Features.Customers.Queries.GetByUserId;
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

    [HttpGet("by-user/{userId:guid}")]
    public async Task<IActionResult> GetCustomerByUserId(Guid userId)
    {
        var query = new GetCustomersByUserIdQuery(userId);

        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerInputModel input)
    {
        var command = new CreateCustomerCommand(input.UserId, input.Name, input.Contact);

        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetCustomerById), new { Id = id }, input);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] UpdateCustomerInputModel input)
    {
        var command = new UpdateCustomerCommand(id, input.NewContact);

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        var command = new DeleteCustomerCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }
}
