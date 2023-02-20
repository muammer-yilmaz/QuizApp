using QuizApp.Application.Common.Constants;

namespace QuizApp.Application.Features.Quiz.Commands.UpdateQuiz;

public sealed record UpdateQuizCommandResponse
{
    public string Message { get; } = Messages.UpdateSuccessful("Quiz");
}
