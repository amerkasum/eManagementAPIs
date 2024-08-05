using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.HelperServices.IHelperService
{
    public interface IHelperService
    {
        List<DateTime> GetCurrentWeek();
    }
}
