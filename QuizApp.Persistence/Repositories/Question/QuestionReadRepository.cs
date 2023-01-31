using QuizApp.Application.Repositories;


namespace QuizApp.Persistence.Repositories
{
    public class QuestionReadRepository : ReadRepository<Domain.Entities.Question>, IQuestionReadRepository
    {
        public QuestionReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
