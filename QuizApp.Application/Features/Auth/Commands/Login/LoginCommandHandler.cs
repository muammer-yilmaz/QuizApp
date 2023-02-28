using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginCommandResponse>
{
    private readonly IAuthService _authService;
    private readonly IRefreshTokenService _refreshTokenService;

    public LoginCommandHandler(IAuthService authService, IRefreshTokenService refreshTokenService)
    {
        _authService = authService;
        _refreshTokenService = refreshTokenService;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _authService.LoginAsync(request);
        await _refreshTokenService.CreateRefreshToken(result.userId, result.Item1.RefreshToken, result.Item1.RefreshTokenExpires);

        return new LoginCommandResponse()
        {
            Token = result.Item1,
        };
    }
}
