﻿using Integration_Project.Data;
using Integration_Project.Models;
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
            return _db.Events.Take(maxEvents).ToListAsync();
        }
    }
}
