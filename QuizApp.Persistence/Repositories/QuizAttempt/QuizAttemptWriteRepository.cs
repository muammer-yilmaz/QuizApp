using QuizApp.Application.Repositories;

namespace QuizApp.Persistence.Repositories.QuizAttempt;

public class QuizAttemptWriteRepository : WriteRepository<Domain.Entities.QuizAttempt>, IQuizAttemptWriteRepository
{
    public QuizAttemptWriteRepository(AppDbContext context) : base(context)
    {
    }
}
