using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Dtos
{
    public class WorkingDaysDto
    {
        public int Id { get; set; }
        public int Day { get; set; }
        public string DayName { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public string ShiftName { get; set; }
        public string ShiftCode { get; set; }
        public string AbsenceTypeName { get; set; }
        public string AbsenceTypeCode { get; set; }
        public string EmployeeFullName { get; set; }
        public int RepeatState { get; set; }
        public bool IsWorking { get; set; }
    }
}
