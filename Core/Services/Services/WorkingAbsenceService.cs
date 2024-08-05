using Core.Services.HelperServices.IHelperService;
using Core.Services.IServices;
using Core.UnitOfWork;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Models.Entities;
using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Services.Services
{
    public class WorkingAbsenceService : IWorkingAbsenceService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IHelperService HelperService;

        public WorkingAbsenceService(IUnitOfWork unitOfWork, IHelperService helperService)
        {
            this.UnitOfWork = unitOfWork;
            this.HelperService = helperService;
        }

        public WorkingAbsenceDatesDto CreateWorkingAbsenceDate(DateTime date, string absenceTypeName, string absenceTypeCode)
        {
            WorkingAbsenceDatesDto result = new WorkingAbsenceDatesDto
            {
                Date = date,
                AbsenceTypeName = absenceTypeName,
                AbsenceTypeCode = absenceTypeCode
            };
            return result;
        }

        public List<WorkingAbsenceDatesDto> GetWorkingAbsenceDatesDtoByParameters(int userId, List<DateTime> dates)
        {
            var workingAbsences = UnitOfWork.WorkingAbsencesRepository.GetWorkingAbsenceDtosByUserIdAndDateRange(userId, dates).ToList();

            List<WorkingAbsenceDatesDto> workingAbsenceDates = new List<WorkingAbsenceDatesDto>();

            foreach (var workingAbsence in workingAbsences)
            {
                if (workingAbsence.EndDate.HasValue)
                {
                    for (DateTime i = workingAbsence.StartDate; i <= workingAbsence.EndDate; i.AddDays(1))
                    {
                        WorkingAbsenceDatesDto x = CreateWorkingAbsenceDate(i, workingAbsence.AbsenceTypeName, workingAbsence.AbsenceTypeCode);
                        workingAbsenceDates.Add(x);
                    }
                }
                else
                {
                    WorkingAbsenceDatesDto x = CreateWorkingAbsenceDate(workingAbsence.StartDate, workingAbsence.AbsenceTypeName, workingAbsence.AbsenceTypeCode);
                    workingAbsenceDates.Add(x);
                }
            }

            return workingAbsenceDates;
        }


    }
}
