using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.QuizAttemp.Queries.GetUserAttempts;

public sealed record GetUserAttemptsQuery() : IQuery<GetUserAttemptsQueryResponse>;
