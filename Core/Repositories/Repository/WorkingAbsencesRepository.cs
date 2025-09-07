using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Helpers.Constants;
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
            var startDate = dates.Min().Date;
            var endDate = dates.Max().Date;

            //Assume this query is right!
            var result = _context.WorkingAbsences.Include(x => x.AbsenceType).Include(x => x.User)
                        .Where(x => x.UserId == userId &&
                        x.StartDate.Date <= endDate &&
                        (x.EndDate == null || x.EndDate.Value.Date >= startDate))
                        .Select(x => new WorkingAbsenceDto
                        {
                            Id = x.Id,
                            StartDate = x.StartDate,
                            EndDate = x.EndDate,
                            AbsenceTypeId = x.AbsenceTypeId,
                            AbsenceTypeName = x.AbsenceType.Name,
                            AbsenceTypeCode = x.AbsenceType.Code,
                            EmployeeFullName = x.User.FullName
                        })
                        .ToList();

            return result;
        }

        public List<WorkingAbsenceBasicDto> GetWorkingAbsences(int userId)
        {
            var userRole = _context.UserRoles.FirstOrDefault(x => x.UserId == userId);
            var role = userRole != null ? _context.Roles.FirstOrDefault(x => x.Id == userRole.RoleId) : null;

            List<WorkingAbsenceBasicDto> result = new List<WorkingAbsenceBasicDto>();

            if (role.Name == nameof(Enumerations.Role.EMPLOYEE))
            {
                result = _context.WorkingAbsences.Include(x => x.AbsenceType)
                .Where(x => userId == x.UserId).Select(x => new WorkingAbsenceBasicDto
                {
                    Id = x.Id,
                    AbsenceType = x.AbsenceType.Name,
                    AbsenceStatus = x.AbsenceStatus.Name,
                    FullName = x.User.FullName,
                    Note = x.Note ?? "No additional data.",
                    ImageUrl = x.User.ImageUrl ?? "assets/user.jpg",
                    Date = x.EndDate != null ? $"{x.StartDate.ToString(Statics.Dates.StandardFormat)} - {x.EndDate.Value.ToString(Statics.Dates.StandardFormat)}" 
                    : x.StartDate.ToString(Statics.Dates.StandardFormat)
                }).OrderBy(x => x.AbsenceType).ToList();
            }
            else
            {
                result = _context.WorkingAbsences.Include(x => x.AbsenceType).Select(x => new WorkingAbsenceBasicDto
                {
                    Id = x.Id,
                    AbsenceType = x.AbsenceType.Name,
                    AbsenceStatus = x.AbsenceStatus.Name,
                    FullName = x.User.FullName,
                    Note = x.Note ?? "No additional data.",
                    ImageUrl = x.User.ImageUrl ?? "assets/user.jpg",
                    Date = x.EndDate != null ? $"{x.StartDate.ToString(Statics.Dates.StandardFormat)} - {x.EndDate.Value.ToString(Statics.Dates.StandardFormat)}" 
                    : x.StartDate.ToString(Statics.Dates.StandardFormat)
                }).OrderBy(x => x.AbsenceType).ToList();
            }


            return result;
        }
    }
}
