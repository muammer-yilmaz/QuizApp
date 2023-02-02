using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Option.Commands.DeleteOption
{
    public class DeleteOptionCommandHandler : ICommandHandler<DeleteOptionCommand, DeleteOptionCommandResponse>
    {
        public Task<DeleteOptionCommandResponse> Handle(DeleteOptionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
