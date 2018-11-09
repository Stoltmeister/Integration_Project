using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public class EventInterestsViewModel
    {
        public Event CurrentEvent { get; set; }
        public List<Interest> Interests { get; set; }
        public List<Interest> AddedInterests { get; set; }
        public Venue CurrentVenue { get; set; }
        public List<StandardUser> Participants { get; set; }
        public StandardUser Organizer { get; set; }
        public int? particpantCount { get; set; }
        public bool isOrganizer { get; set; }
        public string Forecast = "Not Available";
    }
}
