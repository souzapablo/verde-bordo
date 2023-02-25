using MediatR;
using VerdeBordo.Core.Enums;

namespace VerdeBordo.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<Guid>
{
    public CreateUserCommand(string firstName, string lastName, string username, string email, string password, Role role)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Email = email;
        Password = password;
        Role = role;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string Username { get; }
    public string Email { get; }
    public string Password { get; }
    public Role Role { get; }
}