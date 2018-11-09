using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public class EventUserViewModel
    {
        public Event Event { get; set; }
        public StandardUser User { get; set; }
    }
}
