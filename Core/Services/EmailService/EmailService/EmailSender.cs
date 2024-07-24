using Core.Services.EmailService.IEmailService;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.EmailService.EmailService
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string emailTo, string subject, string message)
        {
            var emailFrom = "ib210322@outlook.com";
            var password = "Test1234$.";

            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(emailFrom, password)
            };

            return client.SendMailAsync(new MailMessage(from: emailFrom, to: emailTo, subject, message));
        }
    }
}
