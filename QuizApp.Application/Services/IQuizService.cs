using QuizApp.Application.Features.Quiz.Commands.CreateQuiz;

namespace QuizApp.Application.Services
{
    public interface IQuizService
    {
        public Task CreateQuizAsync(CreateQuizCommand request);
    }
}
