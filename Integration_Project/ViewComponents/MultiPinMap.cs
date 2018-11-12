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
            /* Given a StandardUser's Id, find:
             *  1) The events they are going to
             *  2) The events near them that they are NOT going to.
             */
            
            var output = new List<PinData>();





            var participantsWithMyId = db.Participants.Where(p => p.UserId == id).ToList();

            var myZipcode = db.StandardUsers.Where(s => s.Id == id).Single().ZipCode;
            var eventsAroundMe = db.Events.Where(e => e.VenueId != null).Where(e => e.Venues.Zipcode == myZipcode).ToList();

            var myEvents = new List<Event>();
            foreach (var participant in participantsWithMyId)
            {
                if (eventsAroundMe.Contains(participant.Event) || participant.Event.VenueId == null)
                {
                    continue;
                }
                else
                {
                    myEvents.Add(participant.Event);
                }
            }

            foreach (var _event in eventsAroundMe)
            {
                try
                {
                    output.Add(new PinData("", _event, db));
                }
                catch (NullReferenceException)
                {
                    continue;
                }
            }
            foreach (var _event in myEvents)
            {
                try
                {
                    output.Add(new PinData("https://developers.google.com/maps/documentation/javascript/examples/full/images/beachflag.png", _event, db));
                }
                catch (NullReferenceException)
                {
                    continue;
                }
            }

            //foreach (var participant in participantsWithMyId)
            //{
            //    var EventVenueId = db.Events.Where(x => x.Id == participant.EventId).Select(x => x.VenueId).FirstOrDefault();
            //    if (EventVenueId != null)
            //    {
            //        var pId = participant.Event.VenueId;

            //        var vId = db.Venues.Where(v => v.Id == participant.Event.VenueId).FirstOrDefault();
            //        //var venue = participant.Event.Venues;
            //        var venue = db.Venues.Where(v => v.Id == participant.Event.VenueId).Single();

            //        //Null reference for esoemad5, but not for Test
            //        output.Add(new PinData("P", "eventName", venue.Name, venue.Address, venue.Latitude, venue.Longitude));
            //    }

            //}
            return output;
          
        }

        public class PinData
        {
            public string IconUrl { get; set; }
            //public string Label { get; set; }
            public string EventName { get; set; }
            public string VenueName { get; set; }
            public string Address { get; set; }
            public float Latitude { get; set; }
            public float Longitude { get; set; }

            public PinData(string iconUrl, Event _event, ApplicationDbContext db)
            {
                var venue = db.Venues.Where(v => v.Id == _event.VenueId).Single();
                IconUrl = iconUrl;
                //Label = label;
                EventName = _event.Name;
                VenueName = venue.Name;
                Address = venue.Address;
                Latitude = venue.Latitude;
                Longitude = venue.Longitude;
            }
        }
    }
}