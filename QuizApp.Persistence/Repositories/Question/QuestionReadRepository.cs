using QuizApp.Application.Repositories;


namespace QuizApp.Persistence.Repositories.Question
{
    public class QuestionReadRepository : ReadRepository<Domain.Entities.Question>, IReadRepository<Domain.Entities.Question>
    {
        public QuestionReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
