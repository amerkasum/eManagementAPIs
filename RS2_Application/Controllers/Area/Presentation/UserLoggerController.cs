using Core.Services.EmailService.EmailService;
using Core.Services.EmailService.IEmailService;
using Core.Services.IServices;
using Core.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;

namespace RS2_Application.Controllers.Area.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoggerController : Controller
    {
        private readonly IUnitOfWork DataUnitOfWork;
        private readonly IUserLoggerService UserLoggerService;
        private readonly IEmailSender EmailSender;
        public UserLoggerController(IUnitOfWork unitOfWork, IUserLoggerService userLoggerService, IEmailSender emailSender)
        {
            this.DataUnitOfWork = unitOfWork;
            this.UserLoggerService = userLoggerService;
            this.EmailSender = emailSender;
        }

        [HttpGet(nameof(GetAll))]
        public IEnumerable<UserLogger> GetAll()
        {
            return DataUnitOfWork.UserLoggerRepository.GetAll();
        }

        [HttpPost(nameof(Add))]  
        public IActionResult Add()
        {
            try
            {

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
