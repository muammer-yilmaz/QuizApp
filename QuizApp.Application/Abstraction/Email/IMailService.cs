using QuizApp.Application.Common.DTOs;

namespace QuizApp.Application.Abstraction.Email
{
    public interface IMailService
    {
        Task SendEmailAsync(EmailMessage message);
    }
}
