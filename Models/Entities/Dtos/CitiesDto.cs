using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Dtos
{
    public class CitiesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PttCode { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
