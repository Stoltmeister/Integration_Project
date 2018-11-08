using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public class EventViewModel
    {
        public List<Interest> Interests { get; set; }
        public List<Event> Events { get; set; }
        public Event Event { get; set; }
        public List<SelectListItem> SelectList { get; set; }
        public bool IsOrganizer { get; set; }
    }
}
