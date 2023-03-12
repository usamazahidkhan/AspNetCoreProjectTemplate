using System.Net.Mail;
using System.Net;

namespace ProjectTemplate.Infrastructure.Services
{
    public abstract class EmailServiceBase
    {
        private readonly string smtpServerAddress;
        private readonly int smtpPort;
        private readonly string smtpLoginPassword;
        private readonly string sendFromEmail;

        private readonly SmtpClient _smtpClient;

        protected EmailServiceBase(string smtpServerAddress, int smtpPort, string smtpLoginPassword, string sendFromEmail)
        {
            this.smtpServerAddress = smtpServerAddress;
            this.smtpPort = smtpPort;
            this.smtpLoginPassword = smtpLoginPassword;
            this.sendFromEmail = sendFromEmail;

            _smtpClient = new SmtpClient(smtpServerAddress, smtpPort)
            {
                EnableSsl = true,
                Timeout = 10000,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(sendFromEmail, smtpLoginPassword)
            };
        }

        protected async Task SendAsync(string subject, string body, string sendToEmail)
        {
            var message = GetMailMessageInstance(
                subject,
                body,
                sendFromEmail,
                sendToEmail
            );

            await _smtpClient.SendMailAsync(message);
        }

        private static MailMessage GetMailMessageInstance(string subject, string body, string senderEmail, string reciverEmail)
        {
            var message = new MailMessage
            {
                IsBodyHtml = true,
                From = new MailAddress(senderEmail, subject),
                Subject = subject,
                Body = body
            };

            message.To.Add(reciverEmail);
            return message;
        }

    }
}
