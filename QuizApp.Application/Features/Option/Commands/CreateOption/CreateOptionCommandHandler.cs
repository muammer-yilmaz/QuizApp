using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Option.Commands.CreateOption
{
    public class CreateOptionCommandHandler : ICommandHandler<CreateOptionCommand, CreateOptionCommandResponse>
    {
        public Task<CreateOptionCommandResponse> Handle(CreateOptionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
