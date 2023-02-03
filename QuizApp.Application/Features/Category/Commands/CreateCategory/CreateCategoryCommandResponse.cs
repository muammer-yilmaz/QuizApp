using QuizApp.Application.Common.Consts;

namespace QuizApp.Application.Features.Category.Commands.CreateCategory
{
    public sealed record CreateCategoryCommandResponse
    {
        public string Message {get;} = Messages.CreateSuccessful("Category"); 
    }
    
}
