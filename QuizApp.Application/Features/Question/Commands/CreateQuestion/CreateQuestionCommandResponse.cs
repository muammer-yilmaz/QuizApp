using QuizApp.Application.Common.Consts;

namespace QuizApp.Application.Features.Question.Commands.CreateQuestion
{
    public sealed record CreateQuestionCommandResponse()
    {
       public string Message { get; } = Messages.CreateSuccessful("Question");
    }
}
