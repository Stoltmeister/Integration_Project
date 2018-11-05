using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public class Events
    {
        public int Id { get; set; }
        public int VenueId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Desciption { get; set; }
        public int Premium { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsWeatherDependent { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
