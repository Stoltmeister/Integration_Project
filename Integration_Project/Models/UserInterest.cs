using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public class UserInterest
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("StandardUsers")]
        public string StandardUserId { get; set; }
        public StandardUser StandardUser { get; set; }

        [ForeignKey("Interests")]
        public string InterestId { get; set; }
        public Interest Interest { get; set; }
    }
}
