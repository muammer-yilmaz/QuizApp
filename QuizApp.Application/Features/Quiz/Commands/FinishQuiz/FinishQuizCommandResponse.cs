using QuizApp.Application.Common.DTOs;
using System.Text.Json.Serialization;

namespace QuizApp.Application.Features.Quiz.Commands.FinishQuiz;

public sealed record FinishQuizCommandResponse
{
    public QuizFinishResultDto QuizResult { get; set; }
}
