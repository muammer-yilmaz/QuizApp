using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Question.Commands.DeleteQuestion
{
    public class DeleteQuestionCommandHandler : ICommandHandler<DeleteQuestionCommand, DeleteQuestionCommandResponse>
    {
        public Task<DeleteQuestionCommandResponse> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
