using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Quiz.Queries.GetQuizDetails;

public class GetQuizDetailsQueryHandler : IQueryHandler<GetQuizDetailsQuery, GetQuizDetailsQueryResponse>
{
    private readonly IQuizService _quizService;

    public GetQuizDetailsQueryHandler(IQuizService quizService)
    {
        _quizService = quizService;
    }

    public async Task<GetQuizDetailsQueryResponse> Handle(GetQuizDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await _quizService.GetQuizByIdAsync(request.Id);
        return new(result);
    }
}
