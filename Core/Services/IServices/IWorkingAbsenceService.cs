using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.IServices
{
    public interface IWorkingAbsenceService
    {
        List<WorkingAbsenceDatesDto> GetWorkingAbsenceDatesDtoByParameters(int userId, List<DateTime> dates);
    }
}
