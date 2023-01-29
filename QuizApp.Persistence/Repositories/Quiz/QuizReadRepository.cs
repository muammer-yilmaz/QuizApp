using QuizApp.Application.Repositories;
using QuizApp.Domain.Entities;

namespace QuizApp.Persistence.Repositories.Quiz
{
    public class QuizReadRepository : ReadRepository<Domain.Entities.Quiz>, IReadRepository<Domain.Entities.Quiz>
    {
        public QuizReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
