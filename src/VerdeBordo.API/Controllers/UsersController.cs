using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerdeBordo.Application.Features.Users.Commands.CreateUser;
using VerdeBordo.Application.Features.Users.Queries.GetUserById;
using VerdeBordo.Application.Features.Users.Queries.GetUsers;
using VerdeBordo.Application.InputModels.Users;

namespace VerdeBordo.API.Controllers;

[Route("api/v1/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var query = new GetUsersQuery();

        return Ok(await _mediator.Send(query));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var query = new GetUserByIdQuery(id);

        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserInputModel input)
    {
        var command = new CreateUserCommand(
            input.FirstName, 
            input.LastName, 
            input.Username, 
            input.Email, 
            input.Password, 
            input.Role);
        
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetUserById), new { Id = id }, input);
    }
}