using QuizApp.Application.Common.Constants;

namespace QuizApp.Application.Features.Question.Commands.UpdateQuestion;

public sealed record UpdateQuestionCommandResponse()
{
    public string Message { get; } = Messages.UpdateSuccessful("Question");
}
