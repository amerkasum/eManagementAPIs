using Core.Services.IServices;
using Core.UnitOfWork;
using Helpers.Constants;
using Models.Entities;
using Models.Entities.Dtos;
using RS2_Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IUserLoggerService UserLoggerService;
        public UserService(IUnitOfWork unitOfWork, IUserLoggerService userLoggerService)
        {
            this.UnitOfWork = unitOfWork;
            this.UserLoggerService = userLoggerService;
        }


        public void HandleUserData(UsersViewModel model)
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

            UnitOfWork.UsersRepository.Add(user);
            UnitOfWork.Complete();


            UserRoles userRoles = new UserRoles
            {
                UserId = user.Id,
                RoleId = model.RoleId
            };

            UnitOfWork.UserRolesRepository.Add(userRoles);
            UnitOfWork.Complete();

            List<WorkingDays> workingDays = new List<WorkingDays>
            {
                new WorkingDays
                {
                    Description = null,
                    Day = 1,
                    Date = null,
                    UserId = user.Id,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = true
                },
                new WorkingDays
                {
                    Description = null,
                    Day = 2,
                    Date = null,
                    UserId = user.Id,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = true
                },
                new WorkingDays
                {
                    Description = null,
                    Day = 3,
                    Date = null,
                    UserId = user.Id,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = true
                },
                new WorkingDays
                {
                    Description = null,
                    Day = 4,
                    Date = null,
                    UserId = user.Id,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = true
                },
                new WorkingDays
                {
                    Description = null,
                    Day = 5,
                    Date = null,
                    UserId = user.Id,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = true
                },
                new WorkingDays
                {
                    Description = null,
                    Day = 6,
                    Date = null,
                    UserId = user.Id,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = false
                },
                new WorkingDays
                {
                    Description = null,
                    Day = 7,
                    Date = null,
                    UserId = user.Id,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = false
                }
            };

            UnitOfWork.WorkingDaysRepository.AddRange(workingDays);
            UnitOfWork.Complete();

            UserResidence userResidence = new UserResidence
            {
                UserId = user.Id,
                CityId = model.CityId
            };

            UnitOfWork.UserResidenceRepository.Add(userResidence);
            UnitOfWork.Complete();

        }
    }
}
