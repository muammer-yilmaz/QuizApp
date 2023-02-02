using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Question.Commands.CreateQuestion
{
    public sealed record CreateQuestionCommand : ICommand<CreateQuestionCommandResponse>
    {
    }
}
