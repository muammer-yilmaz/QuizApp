using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Option.Commands.UpdateAnswer;

public class UpdateAnswerCommandHandler : ICommandHandler<UpdateAnswerCommand, UpdateAnswerCommandResponse>
{
    private readonly IOptionService _optionService;

    public UpdateAnswerCommandHandler(IOptionService optionService)
    {
        _optionService = optionService;
    }

    public async Task<UpdateAnswerCommandResponse> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
    {
        await _optionService.UpdateAnswer(request);
        return new();
    }
}
