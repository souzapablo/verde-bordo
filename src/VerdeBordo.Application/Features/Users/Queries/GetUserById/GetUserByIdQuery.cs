using MediatR;
using VerdeBordo.Application.ViewModels.Users;

namespace VerdeBordo.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<UserDetailsViewModel>
{
    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}