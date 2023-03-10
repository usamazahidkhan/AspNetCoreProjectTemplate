using Microsoft.AspNetCore.Identity.UI.Services;

namespace ProjectTemplate.Dashboard.Services
{
    public class AccountEmailSender : EmailServiceBase, IEmailSender
    {
        public AccountEmailSender()
            : base("info@tinytechshop.com", "VPN Reseller Account Confirmation")
        { }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await SendAsync(subject, htmlMessage, email);
        }
    }
}
