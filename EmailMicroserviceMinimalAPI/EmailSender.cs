using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.EmailService.EmailService
{
    public class EmailSender 
    {
        public async Task SendEmailAsync(string emailTo, string subject, string message)
        {
            var emailFrom = "kasumamer@gmail.com"; 
            var password = "wlqt yqvo cwhn ujsv";       

            var client = new SmtpClient("smtp.gmail.com") 
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(emailFrom, password),
                UseDefaultCredentials = false,
                Port = 587
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailFrom),
                Subject = subject,
                Body = message,
                IsBodyHtml = true 
            };

            mailMessage.To.Add(emailTo);

            await client.SendMailAsync(mailMessage);
        }

    }
}