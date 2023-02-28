using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Common.DTOs;

namespace QuizApp.Application.Features.Auth.Commands.RefreshToken;

public sealed record RefreshTokenCommand(
    TokenDto Token
    ) : ICommand<RefreshTokenCommandResponse>;
