using QuizApp.Application.Repositories;
using QuizApp.Domain.Entities;

namespace QuizApp.Persistence.Repositories;

public class RefreshTokenReadRepository : ReadRepository<RefreshToken>, IRefreshTokenReadRepository
{
    public RefreshTokenReadRepository(AppDbContext context) : base(context)
    {
    }
}
