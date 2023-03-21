using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.User.Queries.GetLeaderboard;

public class GetLeaderboardQueryHandler : IQueryHandler<GetLeaderboardQuery, GetLeaderboardQueryResponse>
{
    private readonly IUserService _userService;

    public GetLeaderboardQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetLeaderboardQueryResponse> Handle(GetLeaderboardQuery request, CancellationToken cancellationToken)
    {
        var result = await _userService.GetLeaderboard();
        return new()
        {
            Leaderboard = result,
        };
    }
}
