using Models.Entities;
using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.IRepository
{
    public interface IWorkingAbsencesRepository : IRepository<WorkingAbsences>
    {
        IEnumerable<WorkingAbsenceDto> GetWorkingAbsencesByParameters(string AbsenceTypeCode, int? userId = null);
        List<WorkingAbsenceDto> GetWorkingAbsenceDtosByUserIdAndDateRange(int userId, List<DateTime> dates);
    }
}
