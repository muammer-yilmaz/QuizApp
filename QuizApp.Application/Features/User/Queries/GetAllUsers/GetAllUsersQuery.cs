using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.User.Queries.GetAllUsers;

public sealed record GetAllUsersQuery() : IQuery<GetAllUsersQueryResponse>;
