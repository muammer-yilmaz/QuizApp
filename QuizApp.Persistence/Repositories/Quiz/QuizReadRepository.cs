using QuizApp.Application.Repositories;

namespace QuizApp.Persistence.Repositories
{
    public class QuizReadRepository : ReadRepository<Domain.Entities.Quiz>, IQuizReadRepository
    {
        private readonly AppDbContext _context;
        public QuizReadRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public void GetQuiz()
        {
        }
    }
}
