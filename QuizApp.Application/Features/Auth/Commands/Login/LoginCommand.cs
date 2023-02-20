using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Auth.Commands.Login;

public sealed record LoginCommand(
    string Email,
    string Password
    ) : ICommand<LoginCommandResponse>;
