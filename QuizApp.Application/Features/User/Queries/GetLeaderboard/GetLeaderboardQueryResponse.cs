using QuizApp.Application.Common.DTOs;

namespace QuizApp.Application.Features.User.Queries.GetLeaderboard;

public sealed record GetLeaderboardQueryResponse
{
    public List<LeaderboardDto> Leaderboard { get; set; }
}
