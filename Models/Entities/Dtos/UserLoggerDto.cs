using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Dtos
{
    public class UserLoggerDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AccessType { get; set; }
        public string IpAddress { get; set; }
        public string AccessCode { get; set; }
        public bool IsAccessCodeSent { get; set; }
    }
}
