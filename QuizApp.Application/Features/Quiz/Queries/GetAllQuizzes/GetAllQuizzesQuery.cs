using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Common.DTOs;

namespace QuizApp.Application.Features.Quiz.Queries.GetAllQuizzes;

public sealed record GetAllQuizzesQuery(
    string? SearchText,
    PaginationRequestDto Pagination
    ) : IQuery<GetAllQuizzesQueryResponse>;
