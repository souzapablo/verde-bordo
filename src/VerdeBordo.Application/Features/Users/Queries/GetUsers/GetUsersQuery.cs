using MediatR;
using VerdeBordo.Application.ViewModels.Users;

namespace VerdeBordo.Application.Features.Users.Queries.GetUsers;

public class GetUsersQuery : IRequest<List<UserViewModel>>
{
    
}