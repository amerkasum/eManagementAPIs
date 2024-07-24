using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Entities
{
    public class UserRoles : IEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(UserId))]
        public Users User { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Roles Role { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
