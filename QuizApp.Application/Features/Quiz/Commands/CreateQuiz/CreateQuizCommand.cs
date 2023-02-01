using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Quiz.Commands.CreateQuiz
{
    public sealed record CreateQuizCommand(
        string Title,
        string Description,
        string UserId
        ) : ICommand<CreateQuizCommandResponse>
    {
    }
}
