using QuizApp.Application.Common.Constants;

namespace QuizApp.Application.Features.Category.Commands.CreateCategory;

public sealed record CreateCategoryCommandResponse
{
    public string Message {get;} = Messages.CreateSuccessful("Category"); 
}

