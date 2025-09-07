using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.IServices
{
    public interface IWorkingDaysService
    {
        WorkingDaysDto GetWeeklyWorkingDays(int userId);
    }
}
