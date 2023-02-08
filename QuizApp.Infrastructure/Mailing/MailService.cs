using MailKit.Net.Smtp;
using MimeKit;
using QuizApp.Application.Abstraction.Email;
using QuizApp.Application.Common.Constants;
using QuizApp.Application.Common.DTOs;

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
            //var mail = new MimeMessage();
            //mail.From.Add(new MailboxAddress("QuizApp", _emailConfiguration.Username + "@yandex.com"));
            //mail.To.Add(MailboxAddress.Parse(message.To));
            //mail.Subject = message.Subject;
            //mail.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            //{
            //    Text =  $"This is your confirm code <br> {message.Body} "
            //};
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
            var urlLink = EmailTemplates.LinkBuilder(request.To, token);
            mail.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = request.Body.Replace("|", urlLink)
            };

            await SendEmailAsync(mail);

        }
    }
}
