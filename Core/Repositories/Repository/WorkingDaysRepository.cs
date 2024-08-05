using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;

namespace Core.Repositories.Repository
{
    public class WorkingDaysRepository : Repository<WorkingDays>, IWorkingDaysRepository
    {
        public WorkingDaysRepository(MyContext context) : base(context) { }

        public IEnumerable<WorkingDaysDto> GetWorkingDaysByUserId(int userId)
        {
            IEnumerable<WorkingDaysDto> response = _context.WorkingDays.Include(x => x.Shift).Include(x => x.User)
                .Where(x => x.UserId == userId)
                .Select(x => new WorkingDaysDto
                {
                    Id = x.Id,
                    Day = x.Day,
                    Date = x.Date,
                    ShiftName = x.Shift.Name,
                    ShiftCode = x.Shift.Code,
                    Description = x.Description,
                    EmployeeFullName = x.User.FullName,
                    RepeatState = x.RepeatState,
                    IsWorking = x.IsWorking
                });

            return response;
        }
    }
}
