using QuizApp.Application.Common.Consts;

namespace QuizApp.Application.Features.Auth.Command.CreateUser
{
    public sealed record CreateUserCommandResponse
    {
        public string Message { get; } = Messages.CreateSuccessful("User"); 
    }

}
