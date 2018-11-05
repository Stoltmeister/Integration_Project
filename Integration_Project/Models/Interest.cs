using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public class Interest
    {
        [Key]
        public string Id { get; set; }
        // FK Created by
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Verified { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
