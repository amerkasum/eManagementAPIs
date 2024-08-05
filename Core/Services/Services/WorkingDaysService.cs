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

        public List<WorkingDaysDto> GetWeeklyWorkingDays(int userId)
        {
            List<DateTime> currentWeek = HelperService.GetCurrentWeek();
            List<WorkingDaysDto> workingDays = UnitOfWork.WorkingDaysRepository.GetWorkingDaysByUserId(userId).ToList();

            currentWeek.ForEach(date =>
            {
                WorkingDaysDto weeklyWorkingDay = new WorkingDaysDto
                {
                    Day = (int)date.DayOfWeek == 0 ? (int)date.DayOfWeek + 7 : (int)date.DayOfWeek, //Sunday = 0 + 7 = 7
                    DayName = date.DayOfWeek.ToString().ToUpper(),
                    Date = date,
                    ShiftCode = workingDays.FirstOrDefault(x => x.Day == (int)date.DayOfWeek).ShiftCode,
                    ShiftName = workingDays.FirstOrDefault(x => x.Day == (int)date.DayOfWeek).ShiftName,
                    IsWorking = workingDays.FirstOrDefault(x => x.Day == (int)date.DayOfWeek).IsWorking,
                };

                workingDays.Add(weeklyWorkingDay);
            });

            List<WorkingAbsenceDatesDto> workingAbsenceDates = WorkingAbsenceService.GetWorkingAbsenceDatesDtoByParameters(userId, currentWeek);

            if(workingAbsenceDates != null)
            {
                workingAbsenceDates.ForEach(workingAbsenceDate =>
                {
                    workingDays.ForEach(workingDay =>
                    {
                        if(workingAbsenceDate.Date == workingDay.Date?.Date)
                        {
                            workingDay.ShiftCode = null;
                            workingDay.ShiftName = null;
                            workingDay.IsWorking = false;
                            workingDay.AbsenceTypeName =  workingAbsenceDate.AbsenceTypeName;
                            workingDay.AbsenceTypeCode = workingAbsenceDate.AbsenceTypeCode;
                        }
                    });
                });
            }

            return workingDays;
        }

    }
}
