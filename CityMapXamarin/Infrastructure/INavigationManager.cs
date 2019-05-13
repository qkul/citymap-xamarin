using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using CityMapXamarin.Models;

namespace CityMapXamarin.Infrastructure
{
    public interface INavigationManager
    {
        Task NavigateToCityAsync(City city);
        Task NavigateToMapAsync(IEnumerable<City> cities);
    }
}
