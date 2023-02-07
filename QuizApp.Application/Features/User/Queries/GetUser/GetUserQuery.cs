using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.User.Queries.GetUser
{
    public sealed record GetUserQuery(
        string Id
        ) : IQuery<GetUserQueryResponse>;
}
