using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Option.Commands.DeleteOption
{
    public class DeleteOptionCommandHandler : ICommandHandler<DeleteOptionCommand, DeleteOptionCommandResponse>
    {
        private readonly IOptionService _optionService;

        public DeleteOptionCommandHandler(IOptionService optionService)
        {
            _optionService = optionService;
        }

        public async Task<DeleteOptionCommandResponse> Handle(DeleteOptionCommand request, CancellationToken cancellationToken)
        {
            await _optionService.DeleteOption(request);
            return new();
        }
    }
}
