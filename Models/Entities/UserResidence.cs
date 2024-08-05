using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Entities
{
    public class UserResidence : IEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(UserId))]
        public Users User { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(CityId))]
        public Cities City { get; set; }
        public int CityId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
