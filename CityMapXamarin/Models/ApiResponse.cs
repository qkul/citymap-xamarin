using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CityMapXamarin.Models
{
   public class ApiResponse
    {
        [JsonProperty]
        public IEnumerable<City> Photos { get; set; }
    }
}
