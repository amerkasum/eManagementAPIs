using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Dtos
{
    public class UsersDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string JobPositionCode { get; set; }
        public string JobPositionName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public string Availability { get; set; }
    }
}
