using Helpers.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Dtos.Desktop
{
    public class UsersDesktopDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ContractType { get; set; }
        public DateTime? ContractExpireDate { get; set; }
        public string Position { get; set; }
        public string Availability { get; set; }
        public string FormattedContractExpireDate => ContractExpireDate?.ToString(Statics.Dates.StandardFormat) ?? "No data.";
    }
}
