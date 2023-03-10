using System.Net.Mail;
using System.Net;

namespace ProjectTemplate.Dashboard.Services
{
    public abstract class EmailServiceBase
    {
        private readonly string smtpServerAddress = "smtppro.zoho.com";
        private readonly int smtpPort = 587;
        private readonly string smtpLoginPassword = "g4fHRBULja54";
        private readonly string sendFromEmail;
        private readonly string displayName;

        private readonly SmtpClient _smtpClient;

        protected EmailServiceBase(string sendFromEmail, string displayName)
        {
            this.sendFromEmail = sendFromEmail;
            this.displayName = displayName;

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
                displayName,
                sendFromEmail,
                sendToEmail
            );

            await _smtpClient.SendMailAsync(message);
        }

        private static MailMessage GetMailMessageInstance(string subject, string body, string displayName, string senderEmail, string reciverEmail)
        {
            var message = new MailMessage
            {
                IsBodyHtml = true,
                From = new MailAddress(senderEmail, displayName),
                Subject = subject,
                Body = body
            };

            message.To.Add(reciverEmail);
            return message;
        }

    }
}
