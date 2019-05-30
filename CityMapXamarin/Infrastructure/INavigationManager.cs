using CityMapXamarin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityMapXamarin.Infrastructure
{
    public interface INavigationManager
    {
        Task NavigateToCityAsync(City city);
        Task NavigateToMapAsync(IEnumerable<City> cities);
        Task NavigateToMenu();
    }
}
