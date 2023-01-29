using QuizApp.Application.Repositories;

namespace QuizApp.Persistence.Repositories.Option
{
    public class OptionReadRepository : ReadRepository<Domain.Entities.Option>, IReadRepository<Domain.Entities.Option>
    {
        public OptionReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
