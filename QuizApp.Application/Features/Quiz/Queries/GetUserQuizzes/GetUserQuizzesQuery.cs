using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Quiz.Queries.GetUserQuizzes;

public sealed record GetUserQuizzesQuery() : IQuery<GetUserQuizzesQueryResponse>;
