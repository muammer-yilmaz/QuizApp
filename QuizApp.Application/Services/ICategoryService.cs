using QuizApp.Application.Features.Category.Commands.CreateCategory;
using QuizApp.Application.Features.Category.Commands.DeleteCategory;
using QuizApp.Application.Features.Category.Queries.GetAllCategories;

namespace QuizApp.Application.Services;

public interface ICategoryService
{
    public Task CreateCategory(CreateCategoryCommand request);
    public Task DeleteCategory(DeleteCategoryCommand request);
    public Task<List<CategoryDto>> GetAllCategories(GetAllCategoriesQuery request);
}
