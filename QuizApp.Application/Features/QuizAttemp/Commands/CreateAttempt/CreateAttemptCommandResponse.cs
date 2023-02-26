using QuizApp.Application.Common.Constants;

namespace QuizApp.Application.Features.QuizAttemp.Commands.CreateAttempt;

public sealed record CreateAttemptCommandResponse
{
    public string Message { get; set; } = Messages.CreateSuccessful("Attempt");
}