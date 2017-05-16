using Microsoft.AspNet.Identity;
using System.Net;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace SocialNetwork.api.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridasync(message);
        }

        // Use NuGet to install SendGrid (Basic C# client lib) 
        private async Task configSendGridasync(IdentityMessage message)
        {
            var myMessage = new SendGridMessage();
            myMessage.AddTo(message.Destination);
            myMessage.From = new EmailAddress(
                                "Joe@contoso.com", "Joe S.");
            myMessage.Subject = message.Subject;
            myMessage.PlainTextContent = message.Body;
            myMessage.HtmlContent = message.Body;

            var credentials = ConfigurationManager.AppSettings["apiKey"];

            // Create a Web transport for sending email.
            var client = new SendGridClient(credentials);

            // Send the email.
            if (client != null)
            {
                await client.SendEmailAsync(myMessage);
            }
            else
            {
                Trace.TraceError("Failed to create Web transport.");
                await Task.FromResult(0);
            }
        }
    }
}