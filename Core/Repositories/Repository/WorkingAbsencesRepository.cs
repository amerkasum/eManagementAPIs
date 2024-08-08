using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Repositories.Repository
{
    public class WorkingAbsencesRepository : Repository<WorkingAbsences>, IWorkingAbsencesRepository
    {
        public WorkingAbsencesRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<WorkingAbsenceDto> GetWorkingAbsencesByParameters(string absenceTypeCode, int? userId = null)
        {
            IEnumerable<WorkingAbsenceDto> response = _context.WorkingAbsences
                .Include(x => x.User)
                .Include(x => x.AbsenceType)
                .Where(x => (x.UserId == userId || userId == null) && (x.AbsenceType.Code == absenceTypeCode || absenceTypeCode == null))
                .Select(x => new WorkingAbsenceDto
                {
                    Id = x.Id,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    AbsenceTypeId = x.AbsenceTypeId,
                    AbsenceTypeName = x.AbsenceType.Name,
                    AbsenceTypeCode = x.AbsenceType.Code,
                    EmployeeFullName = x.User.FullName
                });

            return response;
        }

        public List<WorkingAbsenceDto> GetWorkingAbsenceDtosByUserIdAndDateRange(int userId, List<DateTime> dates)
        {
            int datesLength = dates.Count();

            //Assume this query is right!
            List<WorkingAbsenceDto> result = _context.WorkingAbsences.Include(x => x.AbsenceType)
                .Where(x => x.StartDate.Date <= dates[0].Date 
                && (x.EndDate == null || x.EndDate.GetValueOrDefault().Date <= dates[datesLength - 1].Date) 
                && userId == x.UserId).Select(x => new WorkingAbsenceDto
                {
                    Id = x.Id,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    AbsenceTypeId = x.AbsenceTypeId,
                    AbsenceTypeName = x.AbsenceType.Name,
                    AbsenceTypeCode = x.AbsenceType.Code,
                    EmployeeFullName = x.User.FullName
                }).ToList();

            return result;
        }
    }
}
