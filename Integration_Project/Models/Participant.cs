using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public class Participant
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("Event")]
        public string EventId { get; set; }
        public Event Event { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public StandardUser User { get; set; }
        public DateTime InvitedDate { get; set; }
        public DateTime ConfirmedDate { get; set; }
        [ForeignKey("Invite")]
        public string InvitedBy { get; set; }
        public StandardUser Invite { get; set; }
    }
}
