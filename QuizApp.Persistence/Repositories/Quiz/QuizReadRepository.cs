using QuizApp.Application.Repositories;

namespace QuizApp.Persistence.Repositories
{
    public class QuizReadRepository : ReadRepository<Domain.Entities.Quiz>, IQuizReadRepository
    {
        public QuizReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
