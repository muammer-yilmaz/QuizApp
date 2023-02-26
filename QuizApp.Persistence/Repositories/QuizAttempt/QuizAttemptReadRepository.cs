using QuizApp.Application.Repositories;

namespace QuizApp.Persistence.Repositories.QuizAttempt;

public class QuizAttemptReadRepository : ReadRepository<Domain.Entities.QuizAttempt>, IQuizAttemptReadRepository
{
    public QuizAttemptReadRepository(AppDbContext context) : base(context)
    {
    }
}
