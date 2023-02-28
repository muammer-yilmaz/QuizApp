using QuizApp.Application.Repositories;
using QuizApp.Domain.Entities;

namespace QuizApp.Persistence.Repositories;

public class RefreshTokenWriteRepository : WriteRepository<RefreshToken>, IRefreshTokenWriteRepository
{
    public RefreshTokenWriteRepository(AppDbContext context) : base(context)
    {
    }
}