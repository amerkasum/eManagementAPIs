using Core.Services.EmailService.IEmailService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmailSubscriber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly IEmailSender _emailSender;

        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest emailRequest)
        {
            if (emailRequest == null || string.IsNullOrEmpty(emailRequest.EmailTo) || string.IsNullOrEmpty(emailRequest.Subject) || string.IsNullOrEmpty(emailRequest.Message))
            {
                return BadRequest("Invalid email request.");
            }

            await _emailSender.SendEmailAsync(emailRequest.EmailTo, emailRequest.Subject, emailRequest.Message);
            return Ok("Email sent successfully.");
        }
    }

    public class EmailRequest
    {
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
