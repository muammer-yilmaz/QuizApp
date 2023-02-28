using FluentValidation.Results;
using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Auth.Commands.RefreshToken;

public class RefreshTokenCommandHandler : ICommandHandler<RefreshTokenCommand, RefreshTokenCommandResponse>
{
    private readonly IAuthService _authService;
    private readonly IRefreshTokenService _refreshTokenService;

    public RefreshTokenCommandHandler(IAuthService authService, IRefreshTokenService refreshTokenService)
    {
        _authService = authService;
        _refreshTokenService = refreshTokenService;
    }

    public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var newTokenDto = await _refreshTokenService.GetRefreshToken(request.Token);
        await _refreshTokenService.UpdateRefreshToken(request.Token.RefreshToken, newTokenDto);

        return new()
        {
            Token = newTokenDto
        };
    }
}
