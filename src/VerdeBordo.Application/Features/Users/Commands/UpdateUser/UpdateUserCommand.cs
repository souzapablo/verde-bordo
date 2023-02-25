using MediatR;

namespace VerdeBordo.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<Unit>
{
    public UpdateUserCommand(Guid userId, string? newFristName, string? newLastName, string? newUsername)
    {
        UserId = userId;
        NewFristName = newFristName;
        NewLastName = newLastName;
        NewUsername = newUsername;
    }

    public Guid UserId { get; }
    public string? NewFristName { get; }
    public string? NewLastName { get; }
    public string? NewUsername { get; }
}