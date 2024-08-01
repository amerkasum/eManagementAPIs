using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Entities
{
    public class UserTasks : IEntity
    {
        public int Id { get; set; }
        [ForeignKey(nameof(UserId))]
        public Users User { get; set; }
        public int UserId { get;set; }

        [ForeignKey(nameof(TaskId))]
        public Tasks Task { get; set; }
        public int TaskId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
