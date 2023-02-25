using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VerdeBordo.Application.Features.Users.Commands.CreateUser;
using VerdeBordo.Application.Features.Users.Commands.DeleteUser;
using VerdeBordo.Application.Features.Users.Commands.UpdateUser;
using VerdeBordo.Application.Features.Users.Queries.GetUserById;
using VerdeBordo.Application.Features.Users.Queries.GetUsers;
using VerdeBordo.Application.InputModels.Users;

namespace VerdeBordo.API.Controllers;

[ApiController]
[Route("api/v1/users")]
[Authorize]
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

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserInputModel input)
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

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserInputModel input)
    {
        var command = new UpdateUserCommand(id, input.FirstName, input.LastName, input.Username);

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var command = new DeleteUserCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }
}