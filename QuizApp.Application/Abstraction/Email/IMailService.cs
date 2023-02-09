using QuizApp.Application.Common.DTOs;

namespace QuizApp.Application.Abstraction.Email
{
    public interface IMailService
    {
        Task SendEmailConfirmationMail(EmailRequest request, string token);
        Task SendPasswordResetEmail(EmailRequest request, string token);
    }
}
