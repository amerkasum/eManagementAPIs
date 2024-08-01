using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class Events : IEntity
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int CreatedById { get; set; }
        public int EventStatusId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
