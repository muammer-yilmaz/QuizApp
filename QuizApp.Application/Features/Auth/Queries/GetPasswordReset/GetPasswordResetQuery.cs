using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Auth.Queries.GetPasswordReset;

public sealed record GetPasswordResetQuery(
    string Email
    ) : IQuery<GetPasswordResetQueryResponse>;
