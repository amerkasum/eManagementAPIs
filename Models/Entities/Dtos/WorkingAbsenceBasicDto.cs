using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Dtos
{
    public class WorkingAbsenceBasicDto
    {
        public int Id { get; set; }
        public string AbsenceType { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string AbsenceStatus { get; set; }
        public string Date { get; set; }
        public string Note { get; set; }
    }
}
