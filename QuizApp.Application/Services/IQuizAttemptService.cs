using QuizApp.Application.Common.DTOs;

namespace QuizApp.Application.Services;

public interface IQuizAttemptService
{
    public Task CreateAttempt(string quizId);
    public Task UpdateAttempt(QuizFinishResultDto quizFinishResult);
    public Task<List<QuizFinishResultDto>> GetUserAttempts();
}
