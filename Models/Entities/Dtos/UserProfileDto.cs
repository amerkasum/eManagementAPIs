using Helpers.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Dtos
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string JobPosition { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FormattedDateOfBirth => DateOfBirth.ToString(Statics.Dates.StandardFormat);
        public string Availability { get; set; }
        public string Residence { get; set; }
        public string About { get; set; }
        public string ImageUrl { get; set; }
    }
}
