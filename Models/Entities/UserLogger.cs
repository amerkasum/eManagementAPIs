using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Entities
{
    public class UserLogger : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public string AccessCode { get; set; }
        //U slucaju da je access code poslan putem email-a postaviti vrijednost na true.
        public bool IsAccessCodeSent { get; set; }
        [ForeignKey(nameof(UserId))]
        public Users User { get; set; }
        public int UserId { get; set; }
        public string AccessType { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
