using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerdeBordo.Application.Features.Auth.Login;
using VerdeBordo.Application.InputModels.Login;

namespace VerdeBordo.API.Controllers;

[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    public async Task<IActionResult> Login([FromBody] LoginInputModel input)
    {
        var command = new LoginCommand(input.Email, input.Password);

        return Ok(await _mediator.Send(command));
    }   
}