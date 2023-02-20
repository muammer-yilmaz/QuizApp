using QuizApp.Application.Repositories;

namespace QuizApp.Persistence.Repositories;

public class OptionWriteRepository : WriteRepository<Domain.Entities.Option>, IOptionWriteRepository
{
    public OptionWriteRepository(AppDbContext context) : base(context)
    {
    }
}
