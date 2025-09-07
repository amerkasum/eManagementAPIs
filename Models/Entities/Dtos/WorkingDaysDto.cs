using Helpers.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using static Helpers.Constants.Statics;

namespace Models.Entities.Dtos
{
    public class WorkingDaysDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public List<WorkingDaysBasicDto> WorkingDays { get; set; }
    }
}
