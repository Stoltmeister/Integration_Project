using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public class EventInterest
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey("Events")]
        public string EventId { get; set; }
        public Event Events { get; set; }

        [ForeignKey("Interests")]
        public string InterestId { get; set; }
        public Interest Interests { get; set; }
    }
}

