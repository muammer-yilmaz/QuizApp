using MediatR;

namespace QuizApp.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryRequest : IRequest<CreateCategoryResponse>
    {
        public string CategoryName { get; set; }
    }
}
