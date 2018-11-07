using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public class Rating
    {

        [Key]
        public string Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        
        [ForeignKey("Venue")]
        public string VenueId { get; set; }
        public Venue Venue { get; set; }

        [Range(1,5)]
        public decimal Rank { get; set; }
    }
}
