using QuizApp.Application.Common.DTOs;

namespace QuizApp.Application.Features.Auth.Commands.Login
{
    public sealed class LoginCommandResponse
    {
        public Token Token { get; set; }
    }
}
