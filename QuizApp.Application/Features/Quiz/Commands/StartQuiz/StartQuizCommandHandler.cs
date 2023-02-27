using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Quiz.Commands.StartQuiz;

public class StartQuizCommandHandler : ICommandHandler<StartQuizCommand, StartQuizCommandResponse>
{
    private readonly IQuizService _quizService;
    private readonly IQuizAttemptService _quizAttemptService;

    public StartQuizCommandHandler(IQuizService quizService, IQuizAttemptService quizAttemptService)
    {
        _quizService = quizService;
        _quizAttemptService = quizAttemptService;
    }

    public async Task<StartQuizCommandResponse> Handle(StartQuizCommand request, CancellationToken cancellationToken)
    {
        await _quizAttemptService.CreateAttempt(request.QuizId);
        var result = await _quizService.GetQuizDetailsAsync(request.QuizId);
        return new()
        {
            Quiz = result
        };
    }
}
