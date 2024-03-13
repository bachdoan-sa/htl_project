using System;
using Repository.Services.IServices;
using System.Net;
using System.Net.Mail;
using Repository.Settings;

namespace Repository.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailSender(SmtpSettings smtpSettings)
        {
            _smtpSettings = smtpSettings;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port)
            {
                Credentials = new NetworkCredential(_smtpSettings.User, _smtpSettings.Password),
                EnableSsl = true
            };

            await client.SendMailAsync(new MailMessage
            {
                From = new MailAddress(_smtpSettings.User),
                To = { email },
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            });
        }
    }
}


