using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace CityMapXamarin.Models
{
    public class City
    {
        [JsonProperty]
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [JsonProperty]
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [JsonProperty]
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [JsonProperty]
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [JsonProperty]
        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty]
        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }
    }
}
