using QuizApp.Application.Repositories;

namespace QuizApp.Persistence.Repositories
{
    public class QuestionWriteRepository : WriteRepository<Domain.Entities.Question>, IQuestionWriteRepository
    {
        public QuestionWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
