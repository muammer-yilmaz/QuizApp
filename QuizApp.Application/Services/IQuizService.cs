﻿using QuizApp.Application.Features.Quiz.Commands.CreateQuiz;
using QuizApp.Domain.Entities;

namespace QuizApp.Application.Services
{
    public interface IQuizService
    {
        public Task CreateQuizAsync(CreateQuizCommand request);
        public Task DeleteQuizAsync(string id);
        public Task<List<Quiz>> GetAllQuizzesAsync();
    }
}
