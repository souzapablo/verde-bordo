using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerdeBordo.Application.Features.Users.Queries.GetUserById;
using VerdeBordo.Application.Features.Users.Queries.GetUsers;

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
}