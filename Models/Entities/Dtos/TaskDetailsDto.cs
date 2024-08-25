using Helpers.Constants;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Dtos
{
    public class TaskDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public string DueDateFormatted => DueDate != null ? DueDate?.ToString(Statics.Dates.StandardFormat) : "No due date.";
        public string CalculatedDays { get; set; }
        public string Description { get; set; }
        public List<UserPositionBasicDto> Users { get; set; }
        public bool AllowedReview { get; set; }
    }
}
