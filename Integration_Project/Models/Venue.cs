using Integration_Project.Assets;
using System;
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
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        [Display(Name = "Private?")]
        public bool IsPrivate { get; set; }
        [Display(Name = "Website")]
        public string WebsiteUrl { get; set; }

        public void UpdateLatitudeAndLongitude()
        {
            float[] latLng = Geocode.GetLatitudeAndLongitude(Address + " " + Zipcode, ApiKeys.geocodeKey);
            Latitude = latLng[0];
            Longitude = latLng[1];

            return;
        }
    }
}
