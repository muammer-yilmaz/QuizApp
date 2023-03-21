using QuizApp.Application.Common.DTOs;

namespace QuizApp.Application.Features.QuizAttemp.Queries.GetUserAttempts;

public sealed record GetUserAttemptsQueryResponse
{
    public List<QuizFinishResultDto> Attempts { get; set; }
}
