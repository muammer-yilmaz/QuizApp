using QuizApp.Application.Common.DTOs;

namespace QuizApp.Application.Features.Quiz.Commands.StartQuiz;

public sealed record StartQuizCommandResponse
{
    public QuizDetailsDto Quiz { get; set; }
}