using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class EventStatuses : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
