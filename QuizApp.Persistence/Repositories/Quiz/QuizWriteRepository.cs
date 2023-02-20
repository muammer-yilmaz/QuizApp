using QuizApp.Application.Repositories;

namespace QuizApp.Persistence.Repositories;

public class QuizWriteRepository : WriteRepository<Domain.Entities.Quiz>, IQuizWriteRepository
{
    public QuizWriteRepository(AppDbContext context) : base(context)
    {
    }
}
