using QuizApp.Application.Common.DTOs;

namespace QuizApp.Application.Features.Auth.Commands.RefreshToken;

public sealed record RefreshTokenCommandResponse
{
    public TokenDto Token { get; set; }
}