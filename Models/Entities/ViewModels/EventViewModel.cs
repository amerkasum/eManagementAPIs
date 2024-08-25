using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.ViewModels
{
    public class EventViewModel
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int CreatedById { get; set; }
        public string ImageUrl { get; set; }
        public int EventStatusId { get; set; }
    }
}
