using QuizApp.Application.Features.Quiz.Commands.CreateQuiz;
using QuizApp.Application.Services;
using QuizApp.Persistence.Repositories.Quiz;

namespace QuizApp.Persistence.Services
{
    public class QuizService : IQuizService
    {
        private readonly QuizWriteRepository _quizWriteRepository;

        public QuizService(QuizWriteRepository quizWriteRepository)
        {
            _quizWriteRepository = quizWriteRepository;
        }

        public Task<CreateQuizCommandResponse> CreateQuizAsync(CreateQuizCommand request)
        {
            throw new NotImplementedException();
        }
    }
}
