using Models.Entities;
using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.IRepository
{
    public interface IWorkingDaysRepository : IRepository<WorkingDays>
    {
        IEnumerable<WorkingDaysDto> GetWorkingDaysByUserId(int userId);
    }
}
