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
        public DateTime DateOfBirth { get; set; }
        [DefaultValue(false)]
        public bool Active { get; set; }
        public string FullName => FirstName  + " " + LastName;
    }
}
