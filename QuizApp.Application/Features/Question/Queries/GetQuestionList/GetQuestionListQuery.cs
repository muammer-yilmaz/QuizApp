using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Question.Queries.GetQuestionList;

public sealed record GetQuestionListQuery(
    string QuizId
    ) : IQuery<GetQuestionListQueryResponse>;
