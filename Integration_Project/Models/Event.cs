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
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int Premium { get; set; }
        [Display(Name="This Event is private")]
        public bool IsPrivate { get; set; }
        [Display(Name="Outdoors")]
        public bool IsWeatherDependent { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Display(Name = "Minimum Participants")]
        public int MinParticipants { get; set; }
        [Display(Name = "Maximum Participants")]
        public int MaxParticipants { get; set; }
        [Display(Name="Can Invite Participats")]
        public bool CanInviteParticipants { get; set; }
        public byte[] EventPicture { get; set; }

    }
}
