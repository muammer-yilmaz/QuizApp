using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Question.Commands.UpdateQuestion
{
    public class UpdataQuestionCommandHandler : ICommandHandler<UpdateQuestionCommand, UpdateQuestionCommandResponse>
    {
        public Task<UpdateQuestionCommandResponse> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
