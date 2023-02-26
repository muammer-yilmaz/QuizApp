using QuizApp.Application.Features.QuizAttemp.Commands.CreateAttempt;

namespace QuizApp.Application.Services;

public interface IQuizAttemptService
{
    public Task CreateAttempt(CreateAttemptCommand request);
}
