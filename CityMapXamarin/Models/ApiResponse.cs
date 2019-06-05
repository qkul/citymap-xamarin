using Newtonsoft.Json;
using System.Collections.Generic;

namespace CityMapXamarin.Models
{
    public class ApiResponse
    {
        [JsonProperty]
        public IEnumerable<City> Photos { get; set; }
    }
}
