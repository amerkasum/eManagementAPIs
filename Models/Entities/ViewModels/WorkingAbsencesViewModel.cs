using Helpers.Constants;
using System;

namespace RS2_Application.ViewModels
{
    public class WorkingAbsencesViewModel
    {
        public int Id { get; set; }
        public int AbsenceTypeId { get; set; }
        public string AbsenceTypeName { get; set; }
        public string AbsenceTypeCode { get; set; }
        public string EmployeeFullName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string StartDateFormatted => StartDate.ToString(Statics.Dates.StandardFormat);
        public string EndtDateFormatted => EndDate != null ? EndDate?.ToString(Statics.Dates.StandardFormat) : null;
        public bool DailyAbsence => EndDate == null;
    }
}
