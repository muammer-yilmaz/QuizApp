using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.QuizAttemp.Queries.GetUserAttempts;

public class GetUserAttemptsQueryHandler : IQueryHandler<GetUserAttemptsQuery, GetUserAttemptsQueryResponse>
{
    private readonly IQuizAttemptService _quizAttemptService;

    public GetUserAttemptsQueryHandler(IQuizAttemptService quizAttemptService)
    {
        _quizAttemptService = quizAttemptService;
    }

    public async Task<GetUserAttemptsQueryResponse> Handle(GetUserAttemptsQuery request, CancellationToken cancellationToken)
    {
        var result = await _quizAttemptService.GetUserAttempts();
        return new()
        {
            Attempts = result
        };
    }
}
