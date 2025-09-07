using Core.Services.HelperServices.IHelperService;
using Core.Services.IServices;
using Core.UnitOfWork;
using Helpers.Constants;
using Microsoft.VisualBasic;
using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Core.Services.Services
{
    public class WorkingDaysService : IWorkingDaysService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IHelperService HelperService;
        private readonly IWorkingAbsenceService WorkingAbsenceService;

        public WorkingDaysService(IUnitOfWork unitOfWork, IHelperService helperService, IWorkingAbsenceService workingAbsenceService)
        {
            this.UnitOfWork = unitOfWork;
            this.HelperService = helperService;
            this.WorkingAbsenceService = workingAbsenceService;
        }

        public WorkingDaysDto GetWeeklyWorkingDays(int userId)
        {
            var user = UnitOfWork.UsersRepository.GetById(userId);

            List<WorkingDaysBasicDto> workingDaysBasic = UnitOfWork.WorkingDaysRepository.GetWorkingDaysByUserId(userId).ToList();

            WorkingDaysDto workingDays = new WorkingDaysDto
            {
                UserId = user.Id,
                FullName = user.FullName,
                ImageUrl = user.ImageUrl,
                WorkingDays = workingDaysBasic

            };

            return workingDays;
        }

    }
}
