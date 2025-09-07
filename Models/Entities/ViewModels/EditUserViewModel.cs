using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.ViewModels
{
    public class EditUserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public int CityId { get; set; }
        public int ShiftId { get; set; }
        public int PositionId { get; set; }
        public int ContractTypeId { get; set; }
        public DateTime? ContractExpireDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImageUrl { get; set; }
        public string About { get; set; }
    }
}
