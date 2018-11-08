using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public class EventOrganizer
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Events")]
        public string EventId { get; set; }
        public Event Events { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public StandardUser User { get; set; }
        public bool IsCreator { get; set; }
    }

}
