using QuizApp.Application.Common.Consts;

namespace QuizApp.Application.Features.Option.Commands.UpdateOption
{
    public sealed record UpdateOptionCommandResponse()
    {
        public string Message { get; } = Messages.UpdateSuccessful("Option");
    };

}
