using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Quiz.Queries.GetUserQuizzes;

public class GetUserQuizzesQueryHandler : IQueryHandler<GetUserQuizzesQuery, GetUserQuizzesQueryResponse>
{
    private readonly IQuizService _quizService;
public GetUserQuizzesQueryHandler(IQuizService quizService)
    {
        _quizService = quizService;
    }

    public async Task<GetUserQuizzesQueryResponse> Handle(GetUserQuizzesQuery request, CancellationToken cancellationToken)
    {
        var response = await _quizService.GetUserQuizzesAsync();
        return response;
    }
}
