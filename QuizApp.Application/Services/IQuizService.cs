using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Features.Quiz.Commands.CreateQuiz;
using QuizApp.Application.Features.Quiz.Commands.UpdateQuiz;
using QuizApp.Application.Features.Quiz.Queries.GetAllQuizzes;
using QuizApp.Application.Features.Quiz.Queries.GetUserQuizzes;

namespace QuizApp.Application.Services;

public interface IQuizService
{
    public Task CreateQuizAsync(CreateQuizCommand request);
    public Task DeleteQuizAsync(string id);
    public Task UpdateQuizAsync(UpdateQuizCommand request);
    public Task<GetAllQuizzesQueryResponse> GetAllQuizzesAsync(PaginationRequestDto request);
    public Task<GetAllQuizzesQueryResponse> SearchQuizzesAsync(string searchText, PaginationRequestDto pagination);
    public Task<QuizDetailsDto> GetQuizDetailsAsync(string quizId);
    public Task<GetUserQuizzesQueryResponse> GetUserQuizzesAsync();
    public Task<bool> CheckOwnerShip(string quizId);
    public Task<int> CalculateScore(string quizId);
}
