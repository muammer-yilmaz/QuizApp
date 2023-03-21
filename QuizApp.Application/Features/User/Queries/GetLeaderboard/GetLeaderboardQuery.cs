using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.User.Queries.GetLeaderboard;

public sealed record GetLeaderboardQuery() : IQuery<GetLeaderboardQueryResponse>;
