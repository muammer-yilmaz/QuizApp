using QuizApp.Application.Common.Consts;

namespace QuizApp.Application.Features.Auth.Command.CreateUser
{
    public sealed record CreateUserCommandResponse(
        string Success = Messages.CreateUserSuccessful);

}
