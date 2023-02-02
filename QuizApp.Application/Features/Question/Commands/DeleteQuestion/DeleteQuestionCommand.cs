using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Question.Commands.DeleteQuestion
{
    public sealed record DeleteQuestionCommand(
         string Id
        ) : ICommand<DeleteQuestionCommandResponse>;
}
