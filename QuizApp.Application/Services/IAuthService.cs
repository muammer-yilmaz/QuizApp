using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Features.Auth.Commands.ConfirmMail;
using QuizApp.Application.Features.Auth.Commands.Login;

namespace QuizApp.Application.Services
{
    public interface IAuthService
    {
        Task<Token> LoginAsync(LoginCommand request);
        Task ConfirmMail(ConfirmMailCommand request);
    }
}
