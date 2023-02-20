using QuizApp.Application.Common.DTOs;

namespace QuizApp.Application.Features.Quiz.Queries.GetAllQuizzes
{
    public sealed record GetAllQuizzesQueryResponse
    {
        public PaginationResponseDto<List<QuizInfoDto>> Quizzes { get; set; }
    }
}
