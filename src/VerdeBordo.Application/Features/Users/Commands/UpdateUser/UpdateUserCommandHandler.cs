using MediatR;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
            throw new Exception("User not found");
        
        user.UpdateUser(request.NewFristName, request.NewLastName, request.NewUsername);

        await _userRepository.UpdateAsync(user);

        return Unit.Value;
    }
}