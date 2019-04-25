using CityMapXamarin.Infrastructure;
using CityMapXamarin.Models;
using MonkeyCache.SQLite;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CityMapXamarin.Services
{
    public class CityService : ICityService
    {
        private const string ApiUrl = "https://api.myjson.com/bins/7ybe5";

        public async Task<IEnumerable<City>> LoadCitiesAsync()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return Barrel.Current.Get<IEnumerable<City>>(ApiUrl);
            }
            if (!Barrel.Current.IsExpired(ApiUrl))
            {
                return Barrel.Current.Get<IEnumerable<City>>(ApiUrl);
            }

            var client = new HttpClient();
            var responseJson = await client.GetStringAsync(ApiUrl);
            var cities = JsonConvert.DeserializeObject<ApiResponse> (responseJson);
            //Saves the cache and pass it a timespan for expiration
            Barrel.Current.Add(key: ApiUrl, data: cities, expireIn: TimeSpan.FromDays(1));

            return cities.Photos;
        }
    }
}