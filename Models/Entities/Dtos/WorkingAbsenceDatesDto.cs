using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Dtos
{
    public class WorkingAbsenceDatesDto
    {
        public DateTime Date { get; set; }
        public string AbsenceTypeName { get; set; }
        public string AbsenceTypeCode { get; set; }
    }
}
