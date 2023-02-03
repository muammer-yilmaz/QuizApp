using QuizApp.Application.Common.Consts;

namespace QuizApp.Application.Features.Quiz.Commands.UpdateQuiz
{
    public sealed record UpdateQuizCommandResponse
    {
        public string Message { get; } = Messages.UpdateSuccessful("Quiz");
    }
}
