﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Integration_Project.Data;
using Integration_Project.Models;
using Korzh.EasyQuery.Linq;

namespace Integration_Project.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Search
        public async Task<IActionResult> Index()
        {
            var Model = new SearchViewModel();
            List<Event> combinedList = new List<Event>();
            var currentEvents = await _context.Events.Where(x => x.IsPrivate != true).Where(x =>x.Premium == 0).ToListAsync();
            var premEvents = await _context.Events.Where(x => x.Premium == 1).Where(x => x.IsPrivate != true).ToListAsync();
            foreach(var eve in premEvents)
            {
                combinedList.Add(eve);
            }
            foreach(var eve in currentEvents)
            {
                combinedList.Add(eve);
            }
            var currentInterests = await _context.Interests.ToListAsync();
            Model.Events = combinedList;
            Model.Interests = currentInterests;
            return View(Model);
        }

        [HttpPost]
        public IActionResult Index(List<Interest> interests, string text, string Id)
        {
            var eventInterest = _context.EventInterests.ToList();
            var currentEvents = _context.Events.Where(x => x.IsPrivate != true).Where(x => x.Premium == 0).ToList();
            var premEvents = _context.Events.Where(x => x.Premium == 1).Where( x => x.IsPrivate != true).ToList();
            var currentInt = _context.Interests.ToList();
            List<string> interestIds = new List<string>();
            List<List<string>> eventIds = new List<List<string>>();
            List<Event> Events = new List<Event>();
            SearchViewModel VM = new SearchViewModel() { Interests = currentInt};

            //if (!string.IsNullOrEmpty(Id) && string.IsNullOrEmpty(text))
            //{
            //    text = Id;
            //}
            if (!string.IsNullOrEmpty(text))
            {
                interests = _context.Interests.FullTextSearchQuery(text).ToList();
                foreach(var interest in interests)
                {
                    interestIds.Add(interest.Id);
                }
                foreach(var id in interestIds.Distinct())
                {
                    var getEventIds = eventInterest.Where(x => x.InterestId == id).Select(x => x.EventId).ToList();
                    eventIds.Add(getEventIds);
                }
                foreach (var eventIdList in eventIds)
                {
                    foreach (var id in eventIdList.Distinct())
                    {
                        foreach (var prem in premEvents)
                        {
                            if (prem.Id == id)
                            {
                                Events.Add(prem);
                            }
                        }
                    }
                }
                foreach (var eventIdList in eventIds)
                {
                    foreach(var id in eventIdList.Distinct())
                    {
                        foreach(var reg in currentEvents)
                        {
                            if(reg.Id == id)
                            {
                                Events.Add(reg);
                            }
                        }
                    }
                }
                VM.Events = Events;
                return View(VM);
            }
            else if (!string.IsNullOrEmpty(Id))
            {
                var filteredEvents = eventInterest.Where(x => x.InterestId == Id).Select(x => x.EventId).ToList();
                foreach(var id in filteredEvents)
                {
                    var eve = premEvents.Where(x => x.Id == id).FirstOrDefault();
                    if(eve != null)
                    {
                        Events.Add(eve);
                    }
                }
                foreach(var id in filteredEvents.Distinct())
                {
                    var eve = currentEvents.Where(x => x.Id == id).FirstOrDefault();
                    if(eve != null)
                    {
                        Events.Add(eve);
                    }
                }
                VM.Events = Events;
                return View(VM);
            }
            else
            {
                VM.Events = currentEvents;
                return View(VM);
            }
            
        }

        // GET: Search/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interest = await _context.Interests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interest == null)
            {
                return NotFound();
            }

            return View(interest);
        }

        

        // GET: Search/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Search/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Verified,CreationDate")] Interest interest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interest);
        }

        // GET: Search/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interest = await _context.Interests.FindAsync(id);
            if (interest == null)
            {
                return NotFound();
            }
            return View(interest);
        }

        // POST: Search/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description,Verified,CreationDate")] Interest interest)
        {
            if (id != interest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterestExists(interest.Id))
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
            return View(interest);
        }

        // GET: Search/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interest = await _context.Interests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interest == null)
            {
                return NotFound();
            }

            return View(interest);
        }

        // POST: Search/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var interest = await _context.Interests.FindAsync(id);
            _context.Interests.Remove(interest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterestExists(string id)
        {
            return _context.Interests.Any(e => e.Id == id);
        }
    }
}
