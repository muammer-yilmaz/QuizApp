using QuizApp.Application.Common.DTOs;

namespace QuizApp.Application.Abstraction.Email
{
    public interface IMailService
    {
        Task SendEmailConfirmationMail(EmailRequestDto request, string token);
        Task SendPasswordResetEmail(EmailRequestDto request, string token);
    }
}
