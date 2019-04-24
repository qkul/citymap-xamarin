using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CityMapXamarin.Models;

namespace CityMapXamarin.Infrastructure
{
    public interface ICityService
    {
        Task<IEnumerable<City>> LoadCitiesAsync();
    }
}
