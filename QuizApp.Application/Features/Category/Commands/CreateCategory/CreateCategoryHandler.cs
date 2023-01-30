using MediatR;

namespace QuizApp.Application.Features.Category.Commands.CreateCategory
{
    internal class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
    {
        public Task<CreateCategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
