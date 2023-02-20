using MailKit.Net.Smtp;
using MimeKit;
using QuizApp.Application.Abstraction.Email;
using QuizApp.Application.Common.Constants;
using QuizApp.Application.Common.DTOs;

namespace QuizApp.Infrastructure.Mailing
{
    public class MailService : IMailService
    {
        private readonly EmailConfigurationDto _emailConfiguration;

        public MailService(EmailConfigurationDto emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        private async Task SendEmailAsync(MimeMessage mail)
        {
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_emailConfiguration.Host, _emailConfiguration.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_emailConfiguration.Username, _emailConfiguration.Password);
            await smtp.SendAsync(mail);
            await smtp.DisconnectAsync(true);
        }

        public async Task SendEmailConfirmationMail(EmailRequestDto request, string token)
        {
            var mail = new MimeMessage();
            mail.From.Add(new MailboxAddress("QuizApp", _emailConfiguration.Username + "@yandex.com"));
            mail.To.Add(MailboxAddress.Parse(request.To));
            mail.Subject = request.Subject;
            mail.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = EmailTemplates.EmailMessage(EmailTemplates.AccountActivation(request.To,token))
            };

            //await SendEmailAsync(mail);
        }

        public async Task SendPasswordResetEmail(EmailRequestDto request, string token)
        {
            var mail = new MimeMessage();
            mail.From.Add(new MailboxAddress("QuizApp", _emailConfiguration.Username + "@yandex.com"));
            mail.To.Add(MailboxAddress.Parse(request.To));
            mail.Subject = request.Subject;
            mail.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = EmailTemplates.EmailMessage(EmailTemplates.PasswordReset(request.To, token))
            };

            await SendEmailAsync(mail);
        }
    }
}
