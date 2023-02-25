using MediatR;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;
using VerdeBordo.Core.Services;

namespace VerdeBordo.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.IsEmailRegistered(request.Email))
            throw new Exception("E-mail already registered");

        var passwordHash = _authService.ComputeSha256Hash(request.Password);

        var user = new User(
            request.FirstName, 
            request.LastName, 
            request.Username, 
            request.Email, 
            passwordHash, 
            request.Role);
        
        await _userRepository.CreateAsync(user);

        return user.Id;
    }
}