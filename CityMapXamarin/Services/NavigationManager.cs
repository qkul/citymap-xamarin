using CityMapXamarin.Infrastructure;
using CityMapXamarin.Models;
using CityMapXamarin.ViewModels;
using MvvmCross.Navigation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityMapXamarin.Services
{
    public class NavigationManager : INavigationManager
    {
        private readonly IMvxNavigationService _navigationService;

        public NavigationManager(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public async Task NavigateToCityAsync(City city)
        {
            await _navigationService.Navigate<CityDetailsViewModel, City>(city);
        }


        public async Task NavigateToMapAsync(IEnumerable<City> cities)
        {
            await _navigationService.Navigate<CitiesMapViewModel, IEnumerable<City>>(cities);
        }
        public async Task NavigateToMenu()
        {
            await _navigationService.Navigate<SplitRootViewModel>();
        }
    }
}
