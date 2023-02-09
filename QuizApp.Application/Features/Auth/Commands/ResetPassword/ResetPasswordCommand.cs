using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Auth.Commands.ResetPassword;

public sealed record ResetPasswordCommand(
    string Email,
    string Token,
    string NewPassword
    ) : ICommand<ResetPasswordCommandResponse>;
