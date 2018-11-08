using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public class WeatherApi
    {

        public string SetRequestString(string city, string state)
        {
            string request = "https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22" + city + "%2C%20" + state + "%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
            string json = new WebClient().DownloadString(request);
            return json;
        }

        public bool CheckDateRange(DateTime check)
        {
            var startDate = DateTime.Today;
            var dateRange = startDate.AddDays(10);
            return check >= startDate && check <= dateRange;
        }

        public dynamic GetForecast(string json)
        {
            dynamic items = JsonConvert.DeserializeObject(json);
            dynamic forecast = items.query.results.channel.item.forecast;
            return forecast;
        }

        public int GetReal(string json)
        {
            dynamic items = JsonConvert.DeserializeObject(json);

            int real = items.query.results.channel.item.condition.code;
            return real;
        }

        public List<string> types = new List<string>(new string[] {"tornado", "tropical storm", "hurricane", "severe thunderstorms", "thunderstorms", "mixed rain and snow", "mixed rain and sleet", "mixed snow and sleet", "freezing drizzle", "drizzle", "freezing rain",
            "showers", "showers", "snow flurries", "light snow showers", "blowing snow", "snow", "hail", "sleet", "dust", "foggy",
            "haze", "smoky", "blustery", "windy", "cold", "cloudy", "mostly cloudy", "mostly cloudy", "partly cloudy", "partly cloudy",
            "clear", "sunny", "fair", "fair", "mixed rain and hail", "hot", "isolated thunderstorms", "scattered thunderstorms",  "scattered thunderstorms", "scattered showers",
            "heavy snow", "scattered snow shower", "heavy snow", "partly cloudy", "thundershowers", "snow showers", "isolated thundershowers", "not available"});
    }
}
