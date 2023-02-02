using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Option.Commands.UpdateOption
{
    public class UpdateOptionCommandHandler : ICommandHandler<UpdateOptionCommand, UpdateOptionCommandResponse>
    {
        public Task<UpdateOptionCommandResponse> Handle(UpdateOptionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
