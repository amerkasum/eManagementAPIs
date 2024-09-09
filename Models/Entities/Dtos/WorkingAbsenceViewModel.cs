using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Dtos
{
    public class WorkingAbsenceViewModel
    {
        public int AbsenceTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Note { get; set; }
        public int UserId { get; set; }
    }
}
