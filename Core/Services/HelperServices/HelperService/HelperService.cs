using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.HelperServices.HelperService
{
    public class HelperService : IHelperService.IHelperService
    {
        public HelperService() {  }

        public List<DateTime> GetCurrentWeek()
        {
            List<DateTime> week = new List<DateTime>();

            DateTime today = DateTime.Today;
            int delta = DayOfWeek.Monday - today.DayOfWeek;
            DateTime startOfWeek = today.AddDays(delta);

            for (int i = 0; i < 7; i++)
            {
                week.Add(startOfWeek.AddDays(i));
            }

            return week;
        }
    }
}
