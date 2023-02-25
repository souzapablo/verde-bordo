using MediatR;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.IsEmailRegistered(request.Email))
            throw new Exception("E-mail already registered");

        var user = new User(
            request.FirstName, 
            request.LastName, 
            request.Username, 
            request.Email, 
            request.Password, 
            request.Role);
        
        await _userRepository.CreateAsync(user);

        return user.Id;
    }
}