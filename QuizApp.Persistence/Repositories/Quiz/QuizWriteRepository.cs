using QuizApp.Application.Repositories;

namespace QuizApp.Persistence.Repositories.Quiz
{
    public class QuizWriteRepository : WriteRepository<Domain.Entities.Quiz>, IWriteRepository<Domain.Entities.Quiz>
    {
        public QuizWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
