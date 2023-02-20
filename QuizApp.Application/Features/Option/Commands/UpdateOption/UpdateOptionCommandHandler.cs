using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Option.Commands.UpdateOption;

public class UpdateOptionCommandHandler : ICommandHandler<UpdateOptionCommand, UpdateOptionCommandResponse>
{
    private readonly IOptionService _optionService;

    public UpdateOptionCommandHandler(IOptionService optionService)
    {
        _optionService = optionService;
    }

    public async Task<UpdateOptionCommandResponse> Handle(UpdateOptionCommand request, CancellationToken cancellationToken)
    {
        await _optionService.UpdateOption(request);
        return new();
    }
}
