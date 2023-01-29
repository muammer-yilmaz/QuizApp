using QuizApp.Application.Repositories;

namespace QuizApp.Persistence.Repositories.Option
{
    public class OptionWriteRepository : WriteRepository<Domain.Entities.Option>, IWriteRepository<Domain.Entities.Option>
    {
        public OptionWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
