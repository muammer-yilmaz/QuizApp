using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Category.Queries.GetAllCategories;

public sealed record GetAllCategoriesQuery() : IQuery<GetAllCategoriesQueryResponse>;
