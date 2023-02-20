using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Features.Auth.Commands.ConfirmMail;
using QuizApp.Application.Features.Auth.Commands.Login;
using QuizApp.Application.Features.Auth.Commands.ResetPassword;
using QuizApp.Application.Features.Auth.Queries.GetPasswordReset;

namespace QuizApp.Application.Services
{
    public interface IAuthService
    {
        Task<TokenDto> LoginAsync(LoginCommand request);
        Task ConfirmMail(ConfirmMailCommand request);
        Task GetPasswordReset(GetPasswordResetQuery request);
        Task PasswordResetConfirm(ResetPasswordCommand request);
    }
}
