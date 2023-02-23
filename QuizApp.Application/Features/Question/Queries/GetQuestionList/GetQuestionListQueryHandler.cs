using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Question.Queries.GetQuestionList;

public class GetQuestionListQueryHandler : IQueryHandler<GetQuestionListQuery, GetQuestionListQueryResponse>
{
    private readonly IQuestionService _questionService;

    public GetQuestionListQueryHandler(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    public async Task<GetQuestionListQueryResponse> Handle(GetQuestionListQuery request, CancellationToken cancellationToken)
    {
        var result = await _questionService.GetQuestionList(request);
        return new()
        {
            Questions = result
        };
    }
}
