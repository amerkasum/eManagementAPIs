using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Dtos
{
    public class PositionsDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ContractType { get; set; }
        public DateTime? ContractExpireDate { get; set; }
    }
}
