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


        public void HandleUserData(int userId, UsersViewModel model)
        {
            


            UserRoles userRoles = new UserRoles
            {
                UserId = userId,
                RoleId = model.RoleId
            };

            UnitOfWork.UserRolesRepository.Add(userRoles);
            UnitOfWork.SaveChanges();

            List<WorkingDays> workingDays = new List<WorkingDays>
            {
                new WorkingDays
                {
                    Description = null,
                    Day = 1,
                    Date = null,
                    UserId = userId,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = true
                },
                new WorkingDays
                {
                    Description = null,
                    Day = 2,
                    Date = null,
                    UserId = userId,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = true
                },
                new WorkingDays
                {
                    Description = null,
                    Day = 3,
                    Date = null,
                    UserId = userId,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = true
                },
                new WorkingDays
                {
                    Description = null,
                    Day = 4,
                    Date = null,
                    UserId = userId,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = true
                },
                new WorkingDays
                {
                    Description = null,
                    Day = 5,
                    Date = null,
                    UserId = userId,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = true
                },
                new WorkingDays
                {
                    Description = null,
                    Day = 6,
                    Date = null,
                    UserId = userId,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = false
                },
                new WorkingDays
                {
                    Description = null,
                    Day = 7,
                    Date = null,
                    UserId = userId,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = false
                }
            };

            UnitOfWork.WorkingDaysRepository.AddRange(workingDays);
            UnitOfWork.SaveChanges();

            UserResidence userResidence = new UserResidence
            {
                UserId = userId,
                CityId = model.CityId
            };

            UnitOfWork.UserResidenceRepository.Add(userResidence);
            UnitOfWork.SaveChanges();

        }
    }
}
