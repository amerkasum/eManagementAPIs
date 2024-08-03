using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Entities
{
    public class WorkingAbsences : IEntity
    {
        public int Id { get; set; }
        [ForeignKey(nameof(UserId))]
        public Users User { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
