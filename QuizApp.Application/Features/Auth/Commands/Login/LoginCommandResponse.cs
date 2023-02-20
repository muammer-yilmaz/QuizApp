using QuizApp.Application.Common.DTOs;

namespace QuizApp.Application.Features.Auth.Commands.Login
{
    public sealed class LoginCommandResponse
    {
        public TokenDto Token { get; set; }
    }
}
