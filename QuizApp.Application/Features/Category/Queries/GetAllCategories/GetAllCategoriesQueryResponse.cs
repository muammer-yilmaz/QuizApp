namespace QuizApp.Application.Features.Category.Queries.GetAllCategories;

public sealed record GetAllCategoriesQueryResponse
{
    public List<Domain.Entities.Category> Categories { get; set; }
}