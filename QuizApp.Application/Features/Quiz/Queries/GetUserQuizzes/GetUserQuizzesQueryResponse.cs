using QuizApp.Application.Common.DTOs;

namespace QuizApp.Application.Features.Quiz.Queries.GetUserQuizzes;

public sealed record GetUserQuizzesQueryResponse
{
    public List<QuizInfoDto> Quizzes { get; set; }
}