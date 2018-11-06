using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public class VenueInterest
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Venues")]
        public string VenueID { get; set; }
        public Venue Venue { get; set; }

        [ForeignKey("Interests")]
        public string InterestId { get; set; }
        public Interest Interest { get; set; }
    }
}
