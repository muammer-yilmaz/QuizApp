using MediatR;

namespace QuizApp.Application.Features.Auth.Command.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserCommandResponse>
    {
        public string Mail;
        public string Password;
    }
}
