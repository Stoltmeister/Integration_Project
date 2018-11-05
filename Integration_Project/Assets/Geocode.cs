using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Integration_Project.Assets
{
    public static class Geocode
    {
        public static float[] GetLatitudeAndLongitude(string address, string key)
        {
            using (var webClient = new WebClient())
            {
                string rawJson = webClient.DownloadString("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "&key=" + key);
                GeocodePartialJson geocode = JsonConvert.DeserializeObject<GeocodePartialJson>(rawJson);
                return new float[] { geocode.results[0].geometry.location.lat, geocode.results[0].geometry.location.lng };
            }
        }

        private class GeocodePartialJson
        {
            public Results[] results;
            public class Results
            {
                public Geometry geometry;
                public class Geometry
                {
                    public Location location;
                    public class Location
                    {
                        public float lat;
                        public float lng;
                    }
                }
            }
        }
    }
}
