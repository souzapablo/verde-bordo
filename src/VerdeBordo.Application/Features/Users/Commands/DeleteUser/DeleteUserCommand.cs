using MediatR;

namespace VerdeBordo.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<Unit>
{
    public DeleteUserCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}