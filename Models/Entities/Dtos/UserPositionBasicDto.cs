using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Dtos
{
    public class UserPositionBasicDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string PositionName { get; set; }
    }
}
