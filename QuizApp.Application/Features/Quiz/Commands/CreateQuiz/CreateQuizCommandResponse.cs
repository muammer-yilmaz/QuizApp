using QuizApp.Application.Common.Consts;

namespace QuizApp.Application.Features.Quiz.Commands.CreateQuiz
{
    public sealed record CreateQuizCommandResponse(string message = Messages.QuizAdded)
    {
    }
}
