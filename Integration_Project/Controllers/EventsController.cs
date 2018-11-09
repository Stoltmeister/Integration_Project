using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Integration_Project.Data;
using Integration_Project.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNet.Identity;
using Stripe;
using Integration_Project.Assets;
using Event = Integration_Project.Models.Event;

namespace Integration_Project.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var @event = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }
            bool isOrganizer = false;
            StandardUser organizer = new StandardUser();
            var organizerId =  _context.EventOrganizers.Where(e => e.EventId == @event.Id).Select(e => e.UserId).Single();
            organizer = _context.StandardUsers.Where(x => x.ApplicationUserId == organizerId).FirstOrDefault();
            if (User.IsInRole("Standard"))
            {
                var currentUserId = User.Identity.GetUserId();
                var standardUserId = await _context.StandardUsers.Where(u => u.ApplicationUserId == currentUserId).Select(u => u.Id).SingleAsync();
                isOrganizer = standardUserId == organizerId;
            }

            EventInterestsViewModel eveInterests = new EventInterestsViewModel();
            List<Interest> likedInterests = new List<Interest>();

            var currentVenue = _context.Venues.Where(x => x.Id == @event.VenueId).FirstOrDefault();
            var interestEntries = await _context.EventInterests.Include(v => v.Interests).Where(i => i.EventId == @event.Id).ToListAsync();
            foreach (EventInterest i in interestEntries)
            {
                likedInterests.Add(i.Interests);
            }
            if(currentVenue != null)
            {
                WeatherApi weather = new WeatherApi();
                bool checkDate = weather.CheckDateRange(@event.StartDate);
                if(checkDate != false)
                {
                    string request = weather.SetRequestString(currentVenue.City, currentVenue.State);
                    var forecastData = weather.GetForecast(request);
                    TimeSpan dayIndex = @event.StartDate - DateTime.Today;
                    var forecastDay = forecastData[dayIndex.Days];
                    eveInterests.Forecast = forecastDay["text"];
                }
                
            }
            var participants = GetParticipants(@event.Id);
            var PCount = ParticipantsCount(@event.Id);
            eveInterests.Organizer = organizer;
            eveInterests.Participants = participants;
            eveInterests.particpantCount = PCount;
            eveInterests.CurrentVenue = currentVenue;
            eveInterests.AddedInterests = likedInterests;
            eveInterests.Interests = likedInterests;
            eveInterests.CurrentEvent = @event;
            eveInterests.isOrganizer = isOrganizer;
            ViewBag.googleMapsKey = ApiKeys.googleMapsKey;
            return View(eveInterests);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            Event Event = new Event();
            var venues = _context.Venues.ToList();
            var interests = _context.Interests.ToList();
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var item in venues)
            {
                listItems.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id
                });
            }
            EventViewModel VM = new EventViewModel() { Event = Event, Interests = interests, SelectList = listItems };
            return View(VM);
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormFile EventPicture, [Bind("Id,Name,VenueId,StartDate,EndDate,Description,Premium,IsPrivate,IsWeatherDependent,CreatedDate,ModifiedDate,MinParticipants,MaxParticipants,CanInviteParticipants")] Event @event)
        {
            if (ModelState.IsValid)
            {
                string serializedEvent = JsonConvert.SerializeObject(@event);
                return RedirectToAction("ConfirmCreate", new { Event = serializedEvent });
            }
            return View(@event);
        }

        public ActionResult ConfirmCreate(string Event)
        {
            Event eve = JsonConvert.DeserializeObject<Models.Event>(Event);
            TempData["EventRedirect"] = JsonConvert.SerializeObject(eve);
            return View(eve);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmCreate()
        {
            string eventString = (string)TempData["EventRedirect"];
            Event eve = JsonConvert.DeserializeObject<Event>(eventString);
            eve.CreatedDate = DateTime.Today;
            eve.ModifiedDate = DateTime.Today;
            var userId = User.Identity.GetUserId();
            var standardUserId = _context.StandardUsers.Where(x => x.ApplicationUserId == userId).Select(x => x.Id).FirstOrDefault();
            _context.Events.Add(eve);
            await _context.SaveChangesAsync();
            EventOrganizer creator = new EventOrganizer() { EventId = eve.Id, UserId = userId, IsCreator = true };
            _context.EventOrganizers.Add(creator);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = eve.Id });
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,VenueId,Name,StartDate,EndDate,Description,Premium,IsPrivate,IsWeatherDependent,CreatedDate,ModifiedDate,MinParticipants,MaxParticipants,CanInviteParticipants,EventPicture")] Event @event, IFormFile picture)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }
            @event = await StorePicture(@event, picture);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }



        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var @event = await _context.Events.FindAsync(id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(string id)
        {
            return _context.Events.Any(e => e.Id == id);
        }

        public async Task<IActionResult> InterestSelection(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var currentEvent = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (currentEvent == null)
            {
                return NotFound();
            }
            EventInterestsViewModel eventInterests = new EventInterestsViewModel();
            List<Interest> likedInterests = new List<Interest>();
            eventInterests.CurrentEvent = currentEvent;
            var interestEntries = await _context.EventInterests.Include(e => e.Interests).Where(i => i.EventId == currentEvent.Id).ToListAsync(); //try catch?
            var interests = await _context.Interests.ToListAsync();
            foreach (EventInterest i in interestEntries)
            {
                likedInterests.Add(i.Interests);
                interests.Remove(i.Interests);
            }
            eventInterests.AddedInterests = likedInterests;
            eventInterests.Interests = interests;

            return View(eventInterests);
        }

        //AddInterest
        public async Task<IActionResult> AddInterest(string interestId, string eventId)
        {
            var currentEvent = await _context.Events.FirstOrDefaultAsync(v => v.Id == eventId);
            if (currentEvent == null)
            {
                return NotFound();
            }
            EventInterest eventInterest = new EventInterest();
            eventInterest.InterestId = interestId;
            eventInterest.EventId = eventId;
            await _context.EventInterests.AddAsync(eventInterest);
            await _context.SaveChangesAsync();
            return RedirectToAction("InterestSelection", new { id = eventId });
        }

        //RemoveInterest
        public async Task<IActionResult> RemoveInterest(string interestId, string eventId)
        {
            var currentEvent = await _context.Events.FirstOrDefaultAsync(v => v.Id == eventId); //uneeded?
            var currentEventInterests = await _context.EventInterests.Include(v => v.Interests).Where(v => v.EventId == eventId).ToListAsync();
            EventInterest deletingInterest = currentEventInterests.Where(u => u.InterestId == interestId).SingleOrDefault();
            _context.EventInterests.Remove(deletingInterest);
            await _context.SaveChangesAsync();
            return RedirectToAction("InterestSelection", new { id = eventId });
        }

        public IActionResult CreateInterest(string id)
        {
            EventInterestCreator eventInterest = new EventInterestCreator();
            Interest newInterest = new Interest();
            eventInterest.CurrentEventID = id;
            eventInterest.NewInterest = newInterest;
            return View(eventInterest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInterest([Bind("Name,Description")] Interest newInterest, EventInterestCreator eventInterest)
        {
            if (ModelState.IsValid)
            {
                newInterest.CreationDate = DateTime.Today;
                newInterest.Verified = false;
                await _context.AddAsync(newInterest);
                await _context.SaveChangesAsync();
                return RedirectToAction("InterestSelection", new { id = eventInterest.CurrentEventID });
            }
            return View(newInterest);
        }

        private async Task<Event> StorePicture(Event eve, IFormFile picture)
        {
            if (picture != null)
            {
                using (var stream = new MemoryStream())
                {
                    await picture.CopyToAsync(stream);
                    eve.EventPicture = stream.ToArray();
                }
            }

            return eve;
        }

        public IActionResult GetCharge(string id)
        {
            TempData["EventId"] = id;
            TempData["EventId1"] = id;
            return View("StripeCharge");
        }
        [HttpPost]
        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });
            _context.Events.Where(e => e.Id == (string)TempData["EventId1"]).Single().Premium = 1;
            _context.SaveChanges();
            return View("ChargeConfirmation");
        }

        public IActionResult SelectVenue(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TempData["controllerCheck"] = "Event";
            TempData["eventId"] = id;
            var currentVenueId = _context.Events.Where(x => x.Id == id).Select(x => x.VenueId).FirstOrDefault();
            var currentVenue = _context.Venues.Where(x => x.Id == currentVenueId).FirstOrDefault();
            if (currentVenue == null)
            {
                currentVenue = new Venue();
            }
            Event currentEvent = _context.Events.Where(x => x.Id == id).FirstOrDefault();
            EventVenueViewModel eventVenue = new EventVenueViewModel();
            eventVenue.currentVenue = currentVenue;
            eventVenue.currentEvent = currentEvent;
            TempData["startDate"] = currentEvent.StartDate;
            TempData["endDate"] = currentEvent.EndDate;
            TempData["eveId"] = currentEvent.Id;
            var Venues = _context.Venues.ToList();
            eventVenue.Venues = Venues;
            return View(eventVenue);
        }
        [HttpPost]
        public IActionResult SelectVenue(string venueChoice, string id)
        {
            
            return RedirectToAction("ConfirmVenuePick", new { venueId = venueChoice});
        }

        public IActionResult ConfirmVenuePick(string venueId)
        {
            WeatherApi weather = new WeatherApi();
            var start = (DateTime)TempData["startDate"];
            var eveId = (string)TempData["eveId"];
            EventVenueViewModel vm = new EventVenueViewModel();
            var ven = _context.Venues.Where(x => x.Id == venueId).FirstOrDefault();
            var eve = _context.Events.Where(x => x.Id == eveId).FirstOrDefault();
            vm.currentVenue = ven;
            vm.currentEvent = eve;
            bool withinRange = weather.CheckDateRange(start);
            if(withinRange == true)
            {
                string location = weather.SetRequestString(ven.City, ven.State);
                var forecast = weather.GetForecast(location);
                TimeSpan day = start - DateTime.Today;
                var startForecast = forecast[day.Days];
                vm.Forecast = forecast[0].text;
                int code = forecast[0].code;            
                if(code < 20 || (code > 36 && code < 44) || (code > 44 && code < 48))
                {
                    string warning = "Warning, the weather forecast for this venue is poor";
                    vm.Warning = warning;
                }
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult ConfirmVenuePick(IFormCollection form)
        {
            var eveId = form["currentEvent.Id"];
            var venId = form["currentVenue.Id"];
            var eve = _context.Events.Where(x => x.Id == eveId).FirstOrDefault();
            eve.VenueId = venId;
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = eveId});
        }

        public List<StandardUser> GetParticipants(string EventId)
        {
            var participantFilter = _context.Participants.Where(x => x.EventId == EventId).Select(x => x.UserId).ToList();
            List<StandardUser> participants = new List<StandardUser>();
            foreach(var userId in participantFilter)
            {
                var person = _context.StandardUsers.Where(x => x.Id == userId).FirstOrDefault();
                participants.Add(person);
            }
            return participants;
        }

        public int? ParticipantsCount(string EventId) 
        {
            var participantFilter = _context.Participants.Where(x => x.EventId == EventId).Select(x => x.UserId).ToList();
            int? count = participantFilter.Count();
            return count;
        }

        public IActionResult JoinConfirm (string id)
        {
            var eve = _context.Events.Where(x => x.Id == id).FirstOrDefault();
            return View(eve);
        }

        [HttpPost]
        public IActionResult JoinConfirm(string id, string eveId)
        {
            var appId = User.Identity.GetUserId();
            var userId = _context.StandardUsers.Where(x => x.ApplicationUser.Id == appId).Select(x => x.Id).FirstOrDefault();
            Participant part = new Participant();
            part.EventId = id;
            part.UserId = userId;
            part.ConfirmedDate = DateTime.Today;
            _context.Participants.Add(part);
            _context.SaveChanges();
            return RedirectToAction("Details", new {id = id });
        }


        public IActionResult Invite(string id)
        {
            TempData["Id"] = id;
            return View();          
        }

        [HttpPost]
        public async Task<IActionResult> Invite(string email, int x)
        {
            string eventId = (string)TempData["Id"];
            var eo = _context.EventOrganizers.Where(e => e.EventId == eventId).Select(u => u.UserId).Single();
            var standardUser = _context.StandardUsers.Where(u => u.Id == eo).Single();
            var currentEvent = _context.Events.Where(e => e.Id == eventId).Single();
            string body = standardUser.FirstName + " has invited you to their event " + currentEvent.Name + "!" + "\n" +
                "Please follow these instructions to join: \n" +
                "1. If you do not have an account yet please go to localhost and sign up \n" +
                "2. After registering your account please enter the following URL:\n" +
                "localhost:1111/Details/" + eventId + "\n" +
                "3. On the event page click join event if you are able to attend";
            await Sendgrid.SendMail(email, "Your Invited!", body);
            return RedirectToAction("Details", "Events", new { id = eventId });
        }

        public async Task<IActionResult> Profile(string id, string eId)
        {
            var profile = _context.StandardUsers.Where(x => x.Id == id).FirstOrDefault();
            var eve = _context.Events.Where(x => x.Id == eId).FirstOrDefault();
            EventUserViewModel EUVM = new EventUserViewModel();
            EUVM.User = profile;
            EUVM.Event = eve;
            return View(EUVM);
        }

    }
}
