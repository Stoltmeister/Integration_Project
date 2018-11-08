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
    public class MyEvents : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public MyEvents(ApplicationDbContext context)
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
            var myParticipants = _db.Participants.Where(p => p.UserId.Equals(standardUser.Id));
            var query = from p in myParticipants
                        join e in _db.Events on p.EventId equals e.Id
                        select e;
            query = query.Take(maxEvents);

            return query.AsQueryable().ToListAsync();
        }
    }
}
