using QuizApp.Application.Common.Constants;

namespace QuizApp.Application.Features.Option.Commands.UpdateAnswer;

public sealed record UpdateAnswerCommandResponse
{
    public string Message { get; set; } = Messages.UpdateSuccessful("Answer");
}
