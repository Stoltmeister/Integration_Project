﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public class Venue
    {
        [Key]
        public string Id { get; set; }
        // FK CreatedBy
        public string Name { get; set; }
        public string Address { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        [Display(Name = "Private?")]
        public bool IsPrivate { get; set; }
        public string WebsiteUrl { get; set; }
    }
}
