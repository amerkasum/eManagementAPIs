using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.IServices
{
    public interface IEmailServiceClient
    {
        Task SendEmailAsync(string emailTo, string subject, string message);
    }
}
