using QuizApp.Application.Common.Consts;

namespace QuizApp.Application.Features.Option.Commands.CreateOption
{
    public sealed record CreateOptionCommandResponse()
    {
        string Message = Messages.CreateSuccessful("Option");
    } ;
}
