using CityMapXamarin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityMapXamarin.Infrastructure
{
    public interface ICityService
    {
        Task<IEnumerable<City>> LoadCitiesAsync();
    }
}
