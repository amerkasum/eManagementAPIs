using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Entities
{
    public class WorkingDays : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int Day { get; set; }
        public DateTime? Date { get; set; }

        [ForeignKey(nameof(UserId))]
        public Users User { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(ShiftId))]
        public Shifts Shift { get; set; }
        public int ShiftId { get; set; }

        public int RepeatState { get; set; }
        public bool IsWorking { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
