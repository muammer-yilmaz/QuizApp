using QuizApp.Application.Repositories;

namespace QuizApp.Persistence.Repositories.Category
{
    public class CategoryWriteRepository : WriteRepository<Domain.Entities.Category>, IWriteRepository<Domain.Entities.Category>
    {
        public CategoryWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
