using QuizApp.Application.Common.Constants;

namespace QuizApp.Application.Features.Question.Commands.CreateQuestion;

public sealed record CreateQuestionCommandResponse()
{
   public string Message { get; } = Messages.CreateSuccessful("Question");
}
