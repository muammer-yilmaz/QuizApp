namespace QuizApp.Application.Features.Category.Queries.GetAllCategories;

public sealed record GetAllCategoriesQueryResponse
{
    public List<CategoryDto> Categories { get; set; }
}
