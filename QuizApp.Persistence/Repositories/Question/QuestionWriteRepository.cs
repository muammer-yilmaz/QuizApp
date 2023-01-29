using QuizApp.Application.Repositories;

namespace QuizApp.Persistence.Repositories.Question
{
    public class QuestionWriteRepository : WriteRepository<Domain.Entities.Question>, IWriteRepository<Domain.Entities.Question>
    {
        public QuestionWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
