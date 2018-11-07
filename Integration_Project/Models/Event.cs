using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public class Event
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Venues")]
        public string VenueId { get; set; }
        public Venue Venues { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Desciption { get; set; }
        public int Premium { get; set; }
        [Display(Name="This Event is private")]
        public bool IsPrivate { get; set; }
        [Display(Name="Outdoors")]
        public bool IsWeatherDependent { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int MinParticipants { get; set; }
        public int MaxParticipants { get; set; }
        [Display(Name="Can Invite Participats")]
        public bool CanInviteParticipants { get; set; }
    }
}
