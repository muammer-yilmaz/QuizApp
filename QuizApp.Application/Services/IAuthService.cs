using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Features.Auth.Commands.ConfirmMail;
using QuizApp.Application.Features.Auth.Commands.Login;
using QuizApp.Application.Features.Auth.Commands.RefreshToken;
using QuizApp.Application.Features.Auth.Commands.ResetPassword;
using QuizApp.Application.Features.Auth.Queries.GetPasswordReset;

namespace QuizApp.Application.Services;

public interface IAuthService
{
    public Task<(TokenDto, string userId)> LoginAsync(LoginCommand request);
    public Task ConfirmMail(ConfirmMailCommand request);
    public Task GetPasswordReset(GetPasswordResetQuery request);
    public Task PasswordResetConfirm(ResetPasswordCommand request);
    public Task<TokenDto> RefreshToken(RefreshTokenCommand request);
}
