using Core.Services.IServices;
using Core.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models.Entities;
using Models.Entities.Dtos;
using Models.Entities.Dtos.Desktop;
using Models.Entities.Helpers;
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
        private readonly IInitializerService Initializer;
        private readonly IUserService UserService;
        public UsersController(IUnitOfWork unitOfWork, IUserLoggerService userLoggerService, IInitializerService initializer, IUserService userService)
        {
            this.DataUnitOfWork = unitOfWork;
            this.UserLoggerService = userLoggerService;
            this.Initializer = initializer;
            this.UserService = userService;
        }

        [HttpGet(nameof(GetAll))]
        public List<SelectListHelper> GetAll()
        {
            return DataUnitOfWork.UsersRepository.GetSelectLists();
        }

        [HttpGet(nameof(GetUsers))]
        public List<UsersDto> GetUsers()
        {
            var response = DataUnitOfWork.UsersRepository.GetUsers(null).ToList();
            return response;
        }

        [HttpGet(nameof(GetUserProfile))]
        public UserProfileDto GetUserProfile(int userId)
        {
            return DataUnitOfWork.UsersRepository.GetUserProfileDtoByUserId(userId);
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
                DataUnitOfWork.SaveChanges();

                return Ok();
            }
            catch 
            {
                DataUnitOfWork.RollBack();
                return BadRequest();
            }
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] UsersViewModel model)
        {

            if (DataUnitOfWork.UsersRepository.DoesEmailAlreadyExist(model.Email))
                ModelState.AddModelError("Users", "User with this email already exists!");

            if (ModelState.IsValid)
            {
                try
                {
                    Users user = new Users
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Username = $"{model.FirstName.ToLower()}.{model.LastName.ToLower()}",
                        Password = UserLoggerService.EncodePasswordToBase64(model.Password),
                        DateOfBirth = model.DateOfBirth,
                        PhoneNumber = model.PhoneNumber,
                        IsActive = true,
                        ImageUrl = model.ImageUrl
                    };

                    DataUnitOfWork.UsersRepository.Add(user);
                    DataUnitOfWork.SaveChanges();
                    UserService.HandleUserData(user.Id, model);
                    return Ok();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost(nameof(SignIn))]
        public IActionResult SignIn(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Email and password are required.");
            }

            var user = DataUnitOfWork.UsersRepository.GetByUsername(username);

            if (user == null)
            {
                return BadRequest($"User with email '{username}' does not exist.");
            }

            var decodedPassword = UserLoggerService.DecodeFrom64(user.Password);

            if (!password.Equals(decodedPassword))
            {
                return BadRequest("Incorrect password.");
            }

            try
            {
                // Log the user in
                UserLoggerService.CreateUserLog(user.Id);
                return Ok(new { message = "Login successful", userId = user.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        [HttpGet(nameof(GetUsersDesktop))]
        public List<UsersDesktopDto> GetUsersDesktop()
        {
            return DataUnitOfWork.UsersRepository.GetUsersDesktop();
        }

        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(int id)
        {
            var user = DataUnitOfWork.UsersRepository.GetById(id);

            if(user != null)
            {
                DataUnitOfWork.UsersRepository.Remove(user);
                DataUnitOfWork.SaveChanges();
                return Ok(new { message = "User deleted successfuly.", userId = user.Id });
            }
            return BadRequest("User not found.");
        }

        [HttpPost(nameof(InitData))]
        public void InitData()
        {
            Initializer.Initialize();
        }
    }
}
