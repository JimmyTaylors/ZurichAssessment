using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace ZurichAssessment.Services.Imp
{
    public class EmailSender: IEmailSender
    {
        // Our private configuration variables
        private string userName;
        private string password;
        private string smtpClientURL;

        // Get our parameterized configuration
        public EmailSender()
        {
            this.userName = "jimmyliew1997@gmail.com";
            this.password = "juyk reya zagk sjjm";
            this.smtpClientURL = "smtp.gmail.com";
        }

        // Use our configuration to send the email by using SmtpClient
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(userName);
            message.To.Add(new MailAddress(email));
            message.Subject = subject;
            message.Body = htmlMessage;
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient(smtpClientURL)
            {
                Port = 587,
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = true
            };

            return smtpClient.SendMailAsync(message);
        }
    }
}
