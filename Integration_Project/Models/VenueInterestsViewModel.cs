using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public class VenueInterestsViewModel
    {
        public Venue CurrentVenue { get; set; }
        public List<Interest> Interests { get; set; }
        public List<Interest> AddedInterests { get; set; }

        public string controller = "";
        public string eventId = "";
    }
}
