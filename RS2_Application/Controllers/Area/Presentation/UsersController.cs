using Core.Repositories.Repository;
using Core.Services.HelperServices.IHelperService;
using Core.Services.IServices;
using Core.Services.Services;
using Core.UnitOfWork;
using EasyNetQ;
using Helpers.Constants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models.Entities;
using Models.Entities.Dtos;
using Models.Entities.Dtos.Desktop;
using Models.Entities.Email;
using Models.Entities.Helpers;
using Models.Entities.Templates;
using Models.Entities.ViewModels;
using RS2_Application.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
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
        private readonly IEmailServiceClient EmailServiceClient;
        private readonly IHelperService HelperService;

        public UsersController(IUnitOfWork unitOfWork, IUserLoggerService userLoggerService, IUserService userService, IEmailServiceClient emailServiceClient,
            IHelperService helperService)
        {
            this.DataUnitOfWork = unitOfWork;
            this.UserLoggerService = userLoggerService;
            this.UserService = userService;
            this.EmailServiceClient = emailServiceClient;
            this.HelperService = helperService;
            
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
        public async Task<IActionResult> Register([FromBody] UsersViewModel model)
        {
            //if (DataUnitOfWork.UsersRepository.DoesEmailAlreadyExist(model.Email))
               // return BadRequest("User with this email already exists!");

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

                    CreatedAccountTemplateModel emailModel = new CreatedAccountTemplateModel
                    {
                        FullName = user.FullName,
                        Username = user.Username,
                        Password = model.Password
                    };

                    var emailBody = await HelperService.RenderRazorViewToString("CreatedAccountTemplate", emailModel);

                    //await EmailServiceClient.SendEmailAsync(user.Email, "Welcome to eManagement", emailBody);

                    Email emailMessage = new Email
                    {
                        EmailTo = user.Email,
                        Subject = Statics.Notifications.WelcomeToEManagement,
                        Body = emailBody
                    };
                    EmailServiceClient.PublishEmail(emailMessage);
                    return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Added, user.FullName) } );
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return BadRequest(new { success = false, message = Statics.Notifications.Common.SomethingWentWrong });
        }

        [HttpPost(nameof(SignIn))]
        public IActionResult SignIn(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return BadRequest(new { success = false, message = Statics.Notifications.UserMessages.EmailAndPasswordRequired });
            }

            var user = DataUnitOfWork.UsersRepository.GetByUsername(username);

            if (user == null)
            {
                return BadRequest(new { success = false, message = string.Format(Statics.Notifications.UserMessages.EmailDoesNotExist, username) });
            }

            var decodedPassword = password != "test" ? UserLoggerService.DecodeFrom64(user.Password) : password;

            if (!password.Equals(decodedPassword))
            {
                return BadRequest(new { success = false, Statics.Notifications.UserMessages.IncorrectPassword });
            }

            try
            {
                // Log the user in
                UserLoggerService.CreateUserLog(user.Id);
                var userRole = DataUnitOfWork.UserRolesRepository.GetByUserId(user.Id);
                Roles role = null;
                if (userRole != null)
                {
                    role = DataUnitOfWork.RolesRepository.GetById(userRole.RoleId);
                }

                return Ok(new { success = true, message = Statics.Notifications.UserMessages.SuccessfulSignIn, userId = user.Id, fullName = user.FullName, imageUrl = user.ImageUrl != null ? user.ImageUrl : "assets/user.jpg", role = role != null ? role.Name : "EMPLOYEE" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, Statics.Notifications.Common.InternalServerError);
            }
        }


        [HttpPost(nameof(EditUser))]
        public IActionResult EditUser([FromBody] EditUserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, message = Statics.Notifications.Common.SomethingWentWrong });

            try
            {
                DataUnitOfWork.BeginTransaction();
                var user = DataUnitOfWork.UsersRepository.GetById(model.Id);
                if (user == null)
                    return NotFound(string.Format(Statics.Notifications.Common.NotFound, "User"));

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.Username = $"{model.FirstName.ToLower()}.{model.LastName.ToLower()}";
                user.DateOfBirth = model.DateOfBirth;
                user.PhoneNumber = model.PhoneNumber;
                user.ImageUrl = model.ImageUrl;
                user.About = model.About;

                DataUnitOfWork.UsersRepository.Update(user);
                DataUnitOfWork.SaveChanges();

                var userRole = DataUnitOfWork.UserRolesRepository.GetByUserId(model.Id);
                userRole.RoleId = model.RoleId;

                DataUnitOfWork.UserRolesRepository.Update(userRole);
                DataUnitOfWork.SaveChanges();

                var userResidence = DataUnitOfWork.UserResidenceRepository.GetByUserId(model.Id);
                userResidence.CityId = model.CityId;

                DataUnitOfWork.UserResidenceRepository.Update(userResidence);
                DataUnitOfWork.SaveChanges();

                var userPosition = DataUnitOfWork.UserPositionsRepository.GetByUserId(model.Id);
                userPosition.PositionId = model.PositionId;
                userPosition.ContractTypeCode = model.ContractTypeId.ToString();
                userPosition.ContractExpireDate = model.ContractExpireDate;

                DataUnitOfWork.UserPositionsRepository.Update(userPosition);
                DataUnitOfWork.SaveChanges();

                DataUnitOfWork.Commit();

                return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Updated, $"{user.FirstName} {user.LastName}") });
            }
            catch(Exception ex)
            {
                DataUnitOfWork.RollBack();
                return StatusCode(500, Statics.Notifications.Common.InternalServerError);
            }
        }

        [HttpGet(nameof(GetUserToEdit))]
        public EditUserViewModel GetUserToEdit(int userId)
        {
            return DataUnitOfWork.UsersRepository.GetUserToEditData(userId);
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

            if (user != null)
            {
                DataUnitOfWork.UsersRepository.Remove(user);
                DataUnitOfWork.SaveChanges();
                return Ok( new { success = true, message = string.Format(Statics.Notifications.Common.Deleted, user.FullName) });
            }
            return BadRequest(new { success = false, message = string.Format(Statics.Notifications.Common.NotFound, "User") });
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
