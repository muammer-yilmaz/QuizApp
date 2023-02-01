using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Quiz.Commands.DeleteQuiz
{
    public sealed record DeleteQuizCommand(
            string Id
        ) : ICommand<DeleteQuizCommandResponse>
    {
    }
}
