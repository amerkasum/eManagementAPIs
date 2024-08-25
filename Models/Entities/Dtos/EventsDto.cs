using Helpers.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Dtos
{
    public class EventsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public DateTime Date { get; set; }
        public string DateFormatted => Date.ToString(Statics.Dates.StandardFormat);
        public int EventStatusCode { get; set; }
        public string EventStatusName => Enum.GetName(typeof(Enumerations.EventStatus), EventStatusCode);
        public string ImageUrl { get; set; }

    }
}
