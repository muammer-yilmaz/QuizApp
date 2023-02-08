using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Auth.Commands.ConfirmMail;

public sealed record ConfirmMailCommand(
    string Mail,
    string Token
    ) : ICommand<ConfirmMailCommandResponse>;
