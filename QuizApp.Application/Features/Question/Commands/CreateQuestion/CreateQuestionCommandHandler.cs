using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Question.Commands.CreateQuestion
{
    public class CreateQuestionCommandHandler : ICommandHandler<CreateQuestionCommand, CreateQuestionCommandResponse>
    {
        public Task<CreateQuestionCommandResponse> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
