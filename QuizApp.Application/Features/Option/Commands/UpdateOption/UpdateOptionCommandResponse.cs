using QuizApp.Application.Common.Consts;

namespace QuizApp.Application.Features.Option.Commands.UpdateOption
{
    public sealed record UpdateOptionCommandResponse()
    {
        string Message = Messages.UpdateSuccessful("Option");
    };

}
