using System.ComponentModel;
using System;

namespace RS2_Application.ViewModels
{
    public class UsersViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public int CityId { get; set; }
        public int ShiftId { get; set; }
        public int PositionId { get; set; }
        public int ContractTypeId { get; set; }
        public DateTime? ContractExpireDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Active { get; set; }
        public string ImageUrl { get; set; }
    }
}
