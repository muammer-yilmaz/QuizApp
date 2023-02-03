using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Features.Quiz.Commands.CreateQuiz;
using QuizApp.Application.Features.Quiz.Commands.UpdateQuiz;
using QuizApp.Domain.Entities;

namespace QuizApp.Application.Services
{
    public interface IQuizService
    {
        public Task CreateQuizAsync(CreateQuizCommand request);
        public Task DeleteQuizAsync(string id);
        public Task UpdateQuizAsync(UpdateQuizCommand request);
        public Task<List<Quiz>> GetAllQuizzesAsync();
        public Task<QuizDetails> GetQuizByIdAsync(string id);
    }
}
