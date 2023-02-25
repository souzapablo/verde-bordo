using MediatR;
using VerdeBordo.Application.ViewModels.Login;

namespace VerdeBordo.Application.Features.Auth.Login;

public class LoginCommand : IRequest<LoginViewModel>
{
    public LoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; }
    public string Password { get; }
}