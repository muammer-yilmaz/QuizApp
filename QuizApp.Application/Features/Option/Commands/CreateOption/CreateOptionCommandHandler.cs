using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Option.Commands.CreateOption
{
    public class CreateOptionCommandHandler : ICommandHandler<CreateOptionCommand, CreateOptionCommandResponse>
    {
        private readonly IOptionService _optionService;

        public CreateOptionCommandHandler(IOptionService optionService)
        {
            _optionService = optionService;
        }

        public async Task<CreateOptionCommandResponse> Handle(CreateOptionCommand request, CancellationToken cancellationToken)
        {
            await _optionService.CreateOption(request);
            return new();
        }
    }

}
