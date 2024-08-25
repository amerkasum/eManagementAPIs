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
        public int TaskPriorityId { get; set; }
        public int CityId { get; set; }

        //List<UsersDto>
        public List<int> UserIds { get; set; }
    }
}
