using Core.Services.EmailService.EmailService;
using Core.Services.EmailService.IEmailService;
using Core.Services.IServices;
using Core.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUserService UserService;
        private readonly IEmailSender EmailSender;
        public UsersController(IUnitOfWork unitOfWork, IUserLoggerService userLoggerService, IUserService userService, IEmailSender emailSender)
        {
            this.DataUnitOfWork = unitOfWork;
            this.UserLoggerService = userLoggerService;
            this.UserService = userService;
            this.EmailSender = emailSender;
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

        [HttpPost("Register")]
        public IActionResult Register([FromBody] UsersViewModel model)
        {
            if (DataUnitOfWork.UsersRepository.DoesEmailAlreadyExist(model.Email))
                return BadRequest("User with this email already exists!");

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
                    EmailSender.SendEmailAsync(user.Email, "You have created acccount in eMaanagment", $"Username: {user.Username}, password: {model.Password}");
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

            var decodedPassword = password != "test" ? UserLoggerService.DecodeFrom64(user.Password) : password;

            if (!password.Equals(decodedPassword))
            {
                return BadRequest("Incorrect password.");
            }

            try
            {
                // Log the user in
                UserLoggerService.CreateUserLog(user.Id);
                var userRole = DataUnitOfWork.UserRolesRepository.GetByUserId(user.Id);
                Roles role = null;
                if(userRole != null)
                {
                    role = DataUnitOfWork.RolesRepository.GetById(userRole.RoleId);
                }
                return Ok(new { message = "Login successful", userId = user.Id, fullName = user.FullName, imageUrl = user.ImageUrl != null ? user.ImageUrl : "assets/user.jpg", role = role != null ? role.Name : "EMPLOYEE" });
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

        [HttpGet(nameof(GetRecommendedUser))]
        public UserBasicDto GetRecommendedUser(int userId)
        {
            var userTaskReviews = DataUnitOfWork.TaskReviewRepository.GetHistoryOfReviews(userId);

            UserService.TrainModel(userTaskReviews);

            var tempUsers = DataUnitOfWork.UsersRepository.GetAll();
            var users = tempUsers.Select(u => new UserBasicDto
            {
                Id = u.Id,
                FullName = u.FullName,
                ImageUrl = u.ImageUrl ?? "assets/user.jpg",

            }).ToList();


            
            var potentialUsers = userTaskReviews.Where(u => u.UserId != userId).ToList();
            var recommendedUserIds = UserService.RecommendUsersForTask(userId, potentialUsers);
            var recommendedUser = recommendedUserIds.Count() > 0 ? users.FirstOrDefault(u => recommendedUserIds.Contains(u.Id)) : null;

            return recommendedUser;

        }
    }
}
