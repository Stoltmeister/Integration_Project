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
            ViewData["Title"] = "My Events";
            var items = await GetEventsAsync(maxEvents);
            return View("/Views/Shared/Components/EventList/Default.cshtml", items);
        }
        private async Task<List<EventViewModel>> GetEventsAsync(int maxEvents)
        {
            string userId = User.Identity.GetUserId();
            var standardUser = _db.StandardUsers.Where(u => u.ApplicationUserId.Equals(userId)).FirstOrDefault();
            var myParticipants = _db.Participants.Where(p => p.UserId.Equals(standardUser.Id));
            var participantsQuery = from p in myParticipants
                        join e in _db.Events on p.EventId equals e.Id
                        select e;
            participantsQuery = participantsQuery.Take(maxEvents);
            var organizerQuery = from ev in _db.Events
                                 join eo in _db.EventOrganizers on ev.Id equals eo.EventId
                                 where eo.UserId == userId
                                 select ev;

            var eventsResults = participantsQuery.Union(organizerQuery);

            var viewModelResults = new List<EventViewModel>();
            foreach (Event e in eventsResults)
            {
                EventViewModel viewModel = new EventViewModel
                {
                    Event = e,
                    IsOrganizer = organizerQuery.Contains(e)
                };
                viewModelResults.Add(viewModel);
            }
            return viewModelResults;
        }
    }
}
