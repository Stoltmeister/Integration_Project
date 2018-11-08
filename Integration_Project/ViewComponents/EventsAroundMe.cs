using Integration_Project.Data;
using Integration_Project.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.ViewComponents
{
    public class EventsAroundMe : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public EventsAroundMe(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int maxEvents)
        {
            var items = await GetEventsAsync(maxEvents);
            return View(items);
        }
        private Task<List<Event>> GetEventsAsync(int maxEvents)
        {
            string userId = User.Identity.GetUserId();
            var standardUser = _db.StandardUsers.Where(u => u.ApplicationUserId.Equals(userId)).FirstOrDefault();
            int standardUserZipcode = standardUser.ZipCode;
            return _db.Events.Where(e => e.Venues.Zipcode == standardUserZipcode).Take(maxEvents).ToListAsync();
        }
    }
}
