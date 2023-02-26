using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Option.Queries.GetOptionList;

public class GetOptionListQueryHandler : IQueryHandler<GetOptionListQuery, GetOptionListQueryResponse>
{
    private readonly IOptionService _optionService;

    public GetOptionListQueryHandler(IOptionService optionService)
    {
        _optionService = optionService;
    }

    public async Task<GetOptionListQueryResponse> Handle(GetOptionListQuery request, CancellationToken cancellationToken)
    {
        var result = await _optionService.GetOptionListOwner(request);
        return new()
        {
            Options = result
        };
    }
}
