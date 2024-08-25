using Helpers.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Dtos
{
    public class EventsDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public int CreatedById { get; set; }
        public string CreatedByFullName { get; set; }
        public DateTime Date { get; set; }
        public int EventStatusCode { get; set; }
        public string FormattedDate => Date.ToString(Statics.Dates.StandardFormat);   
        public string EventStatusName => Enum.GetName(typeof(Enumerations.EventStatus), EventStatusCode);
        public string ImageUrl { get; set; }
    }
}
