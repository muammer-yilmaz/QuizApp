using QuizApp.Application.Repositories;

namespace QuizApp.Persistence.Repositories;

public class OptionReadRepository : ReadRepository<Domain.Entities.Option>, IOptionReadRepository
{
    public OptionReadRepository(AppDbContext context) : base(context)
    {
    }
}
