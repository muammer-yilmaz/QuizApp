using QuizApp.Application.Common.Constants;

namespace QuizApp.Application.Features.User.Commands.UpdatePassword;

public sealed record UpdatePasswordCommandResponse
{
    public string Message { get; set; } = Messages.UpdateSuccessful("Password");
} 
