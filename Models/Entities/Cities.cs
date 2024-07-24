using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Entities
{
    public class Cities : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(CountryId))]
        public Countries Country { get; set; }
        public int CountryId { get; set; }
        public string PttCode { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
