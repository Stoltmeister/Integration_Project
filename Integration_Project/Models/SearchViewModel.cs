using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Integration_Project.Models
{
    public class SearchViewModel
    {
        public List<Event> Events { get; set; }
        public List<Interest> Interests { get; set; }
        public string Text { get; set; }
    }
}
