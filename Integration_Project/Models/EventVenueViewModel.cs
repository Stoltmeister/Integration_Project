using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public class EventVenueViewModel
    {
        public Venue currentVenue { get; set; }
        public Event currentEvent { get; set; }
        public List<Venue> Venues { get; set; }
        public string Warning = ""; 
        public string Forecast = "Forecast not available";
    }
}
