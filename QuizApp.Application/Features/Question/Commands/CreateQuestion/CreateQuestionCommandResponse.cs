using QuizApp.Application.Common.Consts;

namespace QuizApp.Application.Features.Question.Commands.CreateQuestion
{
    public sealed record CreateQuestionCommandResponse()
    {
        string Message = Messages.CreateSuccessful("Question");
    };
}
