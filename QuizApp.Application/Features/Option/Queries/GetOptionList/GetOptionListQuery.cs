using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Option.Queries.GetOptionList;

public sealed record GetOptionListQuery(
    string QuestionId
    ) : IQuery<GetOptionListQueryResponse>;
