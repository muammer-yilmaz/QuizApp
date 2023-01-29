using QuizApp.Application.Repositories;

namespace QuizApp.Persistence.Repositories.Category
{
    public class CategoryReadRepository : ReadRepository<Domain.Entities.Category>, IReadRepository<Domain.Entities.Category>
    {
        public CategoryReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
