using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Features.QuizAttemp.Commands.CreateAttempt;

namespace QuizApp.Application.Services;

public interface IQuizAttemptService
{
    public Task CreateAttempt(string quizId);
    public Task UpdateAttempt(QuizFinishResultDto quizFinishResult);
}
