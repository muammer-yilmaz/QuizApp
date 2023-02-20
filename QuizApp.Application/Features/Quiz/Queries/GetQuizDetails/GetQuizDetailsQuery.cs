using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Quiz.Queries.GetQuizDetails;

public sealed record GetQuizDetailsQuery(
        string Id
    ) : IQuery<GetQuizDetailsQueryResponse>
{
}
