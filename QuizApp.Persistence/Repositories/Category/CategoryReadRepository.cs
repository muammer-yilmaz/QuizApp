using QuizApp.Application.Repositories;

namespace QuizApp.Persistence.Repositories;

public class CategoryReadRepository : ReadRepository<Domain.Entities.Category>, ICategoryReadRepository
{
    public CategoryReadRepository(AppDbContext context) : base(context)
    {
    }
}
