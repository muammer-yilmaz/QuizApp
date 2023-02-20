using QuizApp.Application.Common.Constants;

namespace QuizApp.Application.Features.Quiz.Commands.CreateQuiz;

public sealed record CreateQuizCommandResponse
{
    public string Message { get; } = Messages.CreateSuccessful("Quiz");
}
