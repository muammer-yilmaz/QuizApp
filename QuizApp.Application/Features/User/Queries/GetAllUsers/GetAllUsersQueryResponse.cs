using QuizApp.Domain.Entities.Identity;

namespace QuizApp.Application.Features.User.Queries.GetAllUsers;

public sealed record GetAllUsersQueryResponse()
{
    public List<AppUser> Users { get; set; }
}