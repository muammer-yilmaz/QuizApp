using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Features.Question.Commands.CreateQuestion;
using QuizApp.Application.Features.Question.Commands.DeleteQuestion;
using QuizApp.Application.Features.Question.Commands.UpdateQuestion;
using QuizApp.Application.Features.Question.Queries.GetQuestionList;

namespace QuizApp.Application.Services;

public interface IQuestionService
{
    public Task<string> CreateQuestion(CreateQuestionCommand request);
    public Task DeleteQuestion(DeleteQuestionCommand request);
    public Task UpdateQuestion(UpdateQuestionCommand request);
    public Task<List<QuestionInfoDto>> GetQuestionList(GetQuestionListQuery request);
    public Task<string> GetQuizId(string questionId);
}
