using QuizApp.Application.Common.Consts;

namespace QuizApp.Application.Features.Option.Commands.CreateOption
{
    public sealed record CreateOptionCommandResponse()
    {
        public string Message { get; } = Messages.CreateSuccessful("Option");
    }
}
