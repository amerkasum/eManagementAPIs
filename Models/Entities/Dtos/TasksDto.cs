using Helpers.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Dtos
{
    public class TasksDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; }
        public string PriorityName => Enum.GetName(typeof(Enumerations.TaskPriority), Priority);
        public int StatusCode { get; set; }
        public string StatusName => Enum.GetName(typeof(Enumerations.TaskStatus), StatusCode);

        //List<UsersDto>
        public List<int> UserIds { get; set; }


    }
}
