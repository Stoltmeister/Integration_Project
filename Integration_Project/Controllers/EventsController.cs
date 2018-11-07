﻿using System;
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

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            EventInterestsViewModel eveInterests = new EventInterestsViewModel();
            var eve = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eve == null)
            {
                return NotFound();
            }
            List<Interest> likedInterests = new List<Interest>();
            var interestEntries = await _context.EventInterests.Include(v => v.Interests).Where(i => i.EventId == eve.Id).ToListAsync();
            foreach (EventInterest i in interestEntries)
            {
                likedInterests.Add(i.Interests);
            }
            eveInterests.AddedInterests = likedInterests;
            eveInterests.Interests = likedInterests;
            eveInterests.CurrentEvent = eve;

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
        public async Task<IActionResult> Create([Bind("Id,Name,VenueId,StartDate,EndDate,Desciption,Premium,IsPrivate,IsWeatherDependent,CreatedDate,ModifiedDate,MinParticipants,MaxParticipants,CanInviteParticipants")] Event @event)
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
            Event eve = JsonConvert.DeserializeObject<Event>(Event);
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
        public async Task<IActionResult> Edit(string id, [Bind("Id,VenueId,StartDate,EndDate,Desciption,Premium,IsPrivate,IsWeatherDependent,CreatedDate,ModifiedDate,MinParticipants,MaxParticipants,CanInviteParticipants")] Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

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
    }
}
