using QuizApp.Application.Repositories;

namespace QuizApp.Persistence.Repositories;

public class CategoryWriteRepository : WriteRepository<Domain.Entities.Category>, ICategoryWriteRepository
{
    public CategoryWriteRepository(AppDbContext context) : base(context)
    {
    }
}
