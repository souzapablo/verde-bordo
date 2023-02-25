using MediatR;
using VerdeBordo.Application.ViewModels.Users;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Users.Queries.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserViewModel>>
{
    private readonly IUserRepository _userRepository;
    
    public GetUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserViewModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();

        return users.Select(x => new UserViewModel(x.Id, x.Username, x.Role == 0 ? "Admin" : "Bordadeira")).ToList();
    }
}