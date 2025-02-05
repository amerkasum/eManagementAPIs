using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.EmailService.IEmailService
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string emailTo, string subject, string message);
    }
}
