using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.QuizAttemp.Commands.CreateAttempt;

public class CreateAttemptCommandHandler : ICommandHandler<CreateAttemptCommand, CreateAttemptCommandResponse>
{
    private readonly IQuizAttemptService _quizAttemptService;

    public CreateAttemptCommandHandler(IQuizAttemptService quizAttemptService)
    {
        _quizAttemptService = quizAttemptService;
    }

    public async Task<CreateAttemptCommandResponse> Handle(CreateAttemptCommand request, CancellationToken cancellationToken)
    {
        await _quizAttemptService.CreateAttempt(request);
        return new();
    }
}
