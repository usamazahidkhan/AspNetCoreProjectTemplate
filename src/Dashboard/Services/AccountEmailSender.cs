using Microsoft.AspNetCore.Identity.UI.Services;
using ProjectTemplate.Infrastructure.Services;

namespace ProjectTemplate.Dashboard.Services
{
    public class AccountEmailSender : EmailServiceBase, IEmailSender
    {
        public AccountEmailSender()
            : base("smtp.server.com", 587, "", "account@myemail.com")
        { }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //await SendAsync(subject, htmlMessage, email);
        }
    }
}
