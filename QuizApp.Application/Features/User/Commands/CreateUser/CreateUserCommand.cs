using MediatR;

namespace QuizApp.Application.Features.Auth.Command.CreateUser
{
    public sealed record CreateUserCommand(
        string UserName,
        string EMail,
        string Password
        ) : IRequest<CreateUserCommandResponse>;
}
