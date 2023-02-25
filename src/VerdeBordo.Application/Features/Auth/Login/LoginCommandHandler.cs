using MediatR;
using VerdeBordo.Application.ViewModels.Login;
using VerdeBordo.Core.Repositories;
using VerdeBordo.Core.Services;

namespace VerdeBordo.Application.Features.Auth.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginViewModel>
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;

    public LoginCommandHandler(IAuthService authService, IUserRepository userRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
    }
    
    public async Task<LoginViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.ComputeSha256Hash(request.Password);

        var user = await _userRepository.GetByEmailAndPasswordAsync(request.Email, passwordHash);

        if (user is null)
            throw new Exception("Invalid e-mail or password");

        var token = _authService.GenerateJwtToken(user.Email, user.Role == 0 ? "Amdin" : "Bordadeira");

        return new LoginViewModel(user.Email, token);
    }
}