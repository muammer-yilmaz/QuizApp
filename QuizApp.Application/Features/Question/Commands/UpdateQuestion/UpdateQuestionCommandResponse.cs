using QuizApp.Application.Common.Consts;

namespace QuizApp.Application.Features.Question.Commands.UpdateQuestion
{
    public sealed record UpdateQuestionCommandResponse()
    {
        string Message = Messages.UpdateSuccessful("Question");
    };
}
