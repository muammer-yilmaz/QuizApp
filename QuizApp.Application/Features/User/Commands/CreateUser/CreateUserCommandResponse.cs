using QuizApp.Application.Common.Constants;

namespace QuizApp.Application.Features.User.Commands.CreateUser;

public sealed record CreateUserCommandResponse
{
    public string Message { get; } = Messages.CreateSuccessful("User");
}

