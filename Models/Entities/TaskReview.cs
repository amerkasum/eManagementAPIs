using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Entities
{
    public class TaskReview : IEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(UserTaskId))]
        public UserTasks UserTask { get; set; }
        public int UserTaskId { get; set; }

        public int Review { get; set; }
        public string Note { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
