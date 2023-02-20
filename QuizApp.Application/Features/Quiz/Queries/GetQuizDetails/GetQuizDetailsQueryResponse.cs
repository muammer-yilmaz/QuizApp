using QuizApp.Application.Common.DTOs;
using QuizApp.Domain.Entities;

namespace QuizApp.Application.Features.Quiz.Queries.GetQuizDetails
{
    public sealed record GetQuizDetailsQueryResponse(
        QuizDetailsDto quiz
        );
}
