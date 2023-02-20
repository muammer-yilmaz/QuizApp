using QuizApp.Application.Common.Constants;

namespace QuizApp.Application.Features.Option.Commands.CreateOption;

public sealed record CreateOptionCommandResponse()
{
    public string Message { get; } = Messages.CreateSuccessful("Options");
}
