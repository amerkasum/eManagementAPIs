using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.ViewModels
{
    public class TaskViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; }
        public string PriorityName { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        //List<UsersDto>
        public List<int> UserIds { get; set; }
    }
}
