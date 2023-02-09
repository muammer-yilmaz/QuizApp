using MailKit.Net.Smtp;
using MimeKit;
using QuizApp.Application.Abstraction.Email;
using QuizApp.Application.Common.Constants;
using QuizApp.Application.Common.DTOs;
using System.Text.RegularExpressions;

namespace QuizApp.Infrastructure.Mailing
{
    public class MailService : IMailService
    {
        private readonly EmailConfiguration _emailConfiguration;

        public MailService(EmailConfiguration emailConfiguration)
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

        public async Task SendEmailConfirmationMail(EmailRequest request, string token)
        {
            var mail = new MimeMessage();
            mail.From.Add(new MailboxAddress("QuizApp", _emailConfiguration.Username + "@yandex.com"));
            mail.To.Add(MailboxAddress.Parse(request.To));
            mail.Subject = request.Subject;
            EmailTemplates.AccountActivation["Link"]
                = EmailTemplates.LinkBuilder(EmailTemplates.AccountActivation["Link"], request.To, token);
            mail.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = ChangeMailBody(request.Body, EmailTemplates.AccountActivation)
            };

            //await SendEmailAsync(mail);
        }

        public async Task SendPasswordResetEmail(EmailRequest request, string token)
        {
            var mail = new MimeMessage();
            mail.From.Add(new MailboxAddress("QuizApp", _emailConfiguration.Username + "@yandex.com"));
            mail.To.Add(MailboxAddress.Parse(request.To));
            mail.Subject = request.Subject;
            EmailTemplates.PasswordReset["Link"]
                = EmailTemplates.LinkBuilder(EmailTemplates.PasswordReset["Link"], request.To, token);
            mail.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = ChangeMailBody(request.Body, EmailTemplates.PasswordReset)
            };

            //await SendEmailAsync(mail);
        }

        private string ChangeMailBody(string body, Dictionary<string, string> values)
        {
            var rgx = new Regex("\\|");
            foreach (var key in values.Keys)
            {
                body = rgx.Replace(body, values[key], 1);
            }
            return body;
        }
    }
}
