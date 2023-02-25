using MediatR;
using VerdeBordo.Application.ViewModels.Users;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsViewModel>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDetailsViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user is null)
            throw new Exception("User not found");

        return new UserDetailsViewModel(user.Id, user.FirstName, user.LastName, user.Username, user.Email, user.Role == 0 ? "Admin" : "Bordadeira");
    }
}