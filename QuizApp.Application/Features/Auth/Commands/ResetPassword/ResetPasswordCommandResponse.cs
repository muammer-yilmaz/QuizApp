using QuizApp.Application.Common.Consts;

namespace QuizApp.Application.Features.Auth.Commands.ResetPassword;

public sealed record ResetPasswordCommandResponse
{
    public string Message { get; set; } = Messages.PasswordResetSuccessful;
}
