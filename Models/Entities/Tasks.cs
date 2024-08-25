using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;

namespace Models.Entities
{
    public class Tasks : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; } //enum
        public int StatusCode { get; set; }

        [ForeignKey(nameof(CityId))]
        public Cities City { get; set; }
        public int CityId { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
