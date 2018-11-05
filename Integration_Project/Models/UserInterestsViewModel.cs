using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public class UserInterestsViewModel
    {
        public StandardUser StandardUser { get; set; }
        public List<Interest> Interests { get; set; }
        public List<Interest> AddedInterests { get; set; }
    }
}
