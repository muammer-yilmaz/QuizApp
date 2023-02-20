using QuizApp.Application.Features.Question.Commands.CreateQuestion;
using QuizApp.Application.Features.Question.Commands.DeleteQuestion;
using QuizApp.Application.Features.Question.Commands.UpdateQuestion;

namespace QuizApp.Application.Services;

public interface IQuestionService
{
    public Task CreateQuestion(CreateQuestionCommand request);
    public Task DeleteQuestion(DeleteQuestionCommand request);
    public Task UpdateQuestion(UpdateQuestionCommand request);
}
