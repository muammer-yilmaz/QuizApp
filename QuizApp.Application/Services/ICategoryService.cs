using QuizApp.Application.Features.Category.Commands.CreateCategory;
using QuizApp.Application.Features.Category.Commands.DeleteCategory;

namespace QuizApp.Application.Services
{
    public interface ICategoryService
    {
        public Task CreateCategory(CreateCategoryCommand request);
        public Task DeleteCategory(DeleteCategoryCommand request);
    }
}
