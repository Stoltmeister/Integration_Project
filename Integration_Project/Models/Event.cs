using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public class Event
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public int VenueId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Desciption { get; set; }
        public int Premium { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsWeatherDependent { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int MinParticipants { get; set; }
        public int MaxParticipants { get; set; }
        public bool CanInviteParticipants { get; set; }
    }
}
