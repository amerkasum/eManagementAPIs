using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
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
        public WorkingDaysRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<WorkingDaysBasicDto> GetWorkingDaysByUserId(int userId)
        {

            IEnumerable<WorkingDaysBasicDto> response = _context.WorkingDays.Include(x => x.Shift)
                .Where(x => x.UserId == userId)
                .Select(x => new WorkingDaysBasicDto
                {
                    WorkingDayId = x.Id,
                    Day = x.Day,
                    ShiftName = x.Shift.Name,
                    ShiftId = x.Shift.Id,
                    IsWorking = x.IsWorking
                });

            return response;
        }
    }
}
