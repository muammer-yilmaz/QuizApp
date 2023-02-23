using QuizApp.Application.Common.DTOs;

namespace QuizApp.Application.Features.Question.Queries.GetQuestionList;

public sealed record GetQuestionListQueryResponse
{
    public List<QuestionInfoDto> Questions { get; set; }
}