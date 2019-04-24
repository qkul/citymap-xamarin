using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CityMapXamarin.Infrastructure;
using CityMapXamarin.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace CityMapXamarin.Services
{
    public class CityService : ICityService
    {
        private const string ApiUrl = "https://api.myjson.com/bins/7ybe5";
        private const string NoInternetConnection = "Sorry but no connection ;(";
        public async Task<IEnumerable<City>> LoadCitiesAsync()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                throw new Exception(NoInternetConnection);
            }

            using (var httpClient = new HttpClient())
            {
                var responseJson = await httpClient.GetStringAsync(ApiUrl);
                var response = JsonConvert.DeserializeObject<ApiResponse>(responseJson);

                return response.Photos;
            }
        }
    }
}