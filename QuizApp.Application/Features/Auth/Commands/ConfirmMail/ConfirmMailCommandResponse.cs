using QuizApp.Application.Common.Constants;

namespace QuizApp.Application.Features.Auth.Commands.ConfirmMail;

public sealed record ConfirmMailCommandResponse
{
    public string Message { get; set; } = Messages.EmailConfirmed;
};