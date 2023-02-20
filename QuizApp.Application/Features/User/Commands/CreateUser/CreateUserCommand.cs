using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.User.Commands.CreateUser
{
    public sealed record CreateUserCommand(
        string UserName,
        string EMail,
        string Password
        ) : ICommand<CreateUserCommandResponse>;
}
