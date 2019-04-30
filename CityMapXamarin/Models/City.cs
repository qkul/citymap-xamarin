using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CityMapXamarin.Models
{
    public class City
    {
        [JsonProperty]
        public string Title { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        [JsonProperty]
        public string Url { get; set; }
        [JsonProperty]
        public double Latitude { get; set; }
        [JsonProperty]
        public double Longitude { get; set; }
    }
}
