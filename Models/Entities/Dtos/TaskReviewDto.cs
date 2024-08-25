using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Dtos
{
    public class TaskReviewDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int TaskId { get; set; }
        public int Review { get; set; }
        public string Note { get; set; }
    }
}
