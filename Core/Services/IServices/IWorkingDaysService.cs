using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.IServices
{
    public interface IWorkingDaysService
    {
        List<WorkingDaysDto> GetWeeklyWorkingDays(int userId);
    }
}
