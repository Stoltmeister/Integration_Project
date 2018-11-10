using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration_Project.Data;
using Integration_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Integration_Project.ViewComponents
{
    public class MultiPinMap : ViewComponent
    {
        private readonly ApplicationDbContext db;
        public MultiPinMap(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            return View("/Views/Shared/Components/MultiPinMap.cshtml", await GetPinDataAsync(id));
        }

        private async Task<List<PinData>> GetPinDataAsync(string id)
        {
            var output = new List<PinData>();
            
            var participantsWithMyId = db.Participants.Where(p => p.UserId == id).ToList();
            
            foreach (var participant in participantsWithMyId)
            {
                var EventVenueId = db.Events.Where(x => x.Id == participant.EventId).Select(x => x.VenueId).FirstOrDefault();
                if (EventVenueId != null)
                {
                    //var venue = participant.Event.Venues;
                    var venue = db.Venues.Where(v => v.Id == participant.Event.VenueId).Single();

                    //Null reference for esoemad5, but not for Test
                    output.Add(new PinData("P", venue.Name, venue.Address, venue.Latitude, venue.Longitude));
                }
                
            }
            return output;
          
        }

        public class PinData
        {
            public string Label { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public float Latitude { get; set; }
            public float Longitude { get; set; }
            public PinData(string label, string name, string address, float latitude, float longitude)
            {
                Label = label;
                Name = name;
                Address = address;
                Latitude = latitude;
                Longitude = longitude;
            }
        }
    }
}