using Core.Services.IServices;
using Core.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models.Entities;
using RS2_Application.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace RS2_Application.Controllers.Area.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUnitOfWork DataUnitOfWork;
        private readonly IUserLoggerService UserLoggerService;
        public UsersController(IUnitOfWork unitOfWork, IUserLoggerService userLoggerService)
        {
            this.DataUnitOfWork = unitOfWork;
            this.UserLoggerService = userLoggerService;
        }

        [HttpGet("GetAllAsync")]
        public async Task<ActionResult<List<Users>>> GetAllAsync()
        {
            var encodedPassword = UserLoggerService.EncodePasswordToBase64("Test1234.");
            var decodedPassword = UserLoggerService.DecodeFrom64(encodedPassword);

            var response = (await DataUnitOfWork.UsersRepository.GetAllAsync()).ToList();
            return Ok(response);
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] UsersViewModel model)
        {
            try
            {
                Users user = new Users
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = UserLoggerService.EncodePasswordToBase64(model.Password),
                    DateOfBirth = model.DateOfBirth,
                    PhoneNumber = model.PhoneNumber,
                    IsActive = true
                };

                DataUnitOfWork.UsersRepository.Add(user);
                DataUnitOfWork.Complete();

                return Ok();
            }
            catch 
            {
                DataUnitOfWork.RollBack();
                return BadRequest();
            }
        }

        [HttpPost("Register")]
        public IActionResult Register(UsersViewModel model)
        {

            if (DataUnitOfWork.UsersRepository.DoesEmailAlreadyExist(model.Email))
                ModelState.AddModelError("Users", "User with this email already exists!");

            if (ModelState.IsValid)
            {
                try
                {
                    Add(model);
                    return Ok();
                }
                catch
                {
                    return BadRequest();
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost(nameof(SignIn))]
        public IActionResult SignIn(string email, string password)
        {
            var user = DataUnitOfWork.UsersRepository.GetByEmail(email);

            if (user == null)
                ModelState.AddModelError("User", $"User with {email} email does not exist.");

            if(user!= null)
            {
                if (!password.Equals(UserLoggerService.DecodeFrom64(user.Password)))
                    ModelState.AddModelError("User", "Incorrect password.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    UserLoggerService.CreateUserLog(user.Id);
                    return Ok();
                }
                catch
                {
                    return BadRequest();
                }
            }
            return BadRequest(ModelState);
        }
    }
}
