using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Category.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, GetAllCategoriesQueryResponse>
{
    private readonly ICategoryService _categoryService;

    public GetAllCategoriesQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<GetAllCategoriesQueryResponse> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _categoryService.GetAllCategories(request);
    }
}
