using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Quiz.Queries.GetAllQuizzes
{
    public sealed record GetAllQuizzesQuery : IQuery<GetAllQuizzesQueryResponse>
    {
    }
}
