using Helpers.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Dtos
{
    public class WorkingDaysBasicDto
    {
        public int WorkingDayId { get; set; }
        public int Day { get; set; }
        public string DayName => ((Enumerations.DayName)Day).ToString();
        public int ShiftId { get; set; }
        public string ShiftName { get; set; }
        public bool IsWorking { get; set; }
    }
}
