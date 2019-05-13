using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CityMapXamarin.Infrastructure;
using CityMapXamarin.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace CityMapXamarin.ViewModels
{
    public class MainPageViewModel : MvxViewModel
    {
        private readonly INavigationManager _navigationManager;
        private readonly ICityService _cityService;

        private IEnumerable<City> _cities;


        public  IMvxCommand NavigateToMapAsyncCommand  => new MvxAsyncCommand(DoNavigateToMapAsync);

        public IMvxCommand NavigateToCityAsyncCommand => new MvxAsyncCommand<City>(DoNavigateToCityAsync);

        public MainPageViewModel(INavigationManager navigationManager, ICityService cityService)
        {
            _navigationManager = navigationManager;
            _cityService = cityService;
        }

        public IEnumerable<City> Cities
        {
            get => _cities;
            set
            {
                _cities = value;
                RaisePropertyChanged(() => Cities);
            }
        }

        public override async void ViewCreated()
        {
            base.ViewCreated();
            Cities = await _cityService.LoadCitiesAsync();
        }


        private async Task DoNavigateToMapAsync()
        {
            await _navigationManager.NavigateToMapAsync(_cities);
        }

      
        private async Task DoNavigateToCityAsync(City city)
        {
            await _navigationManager.NavigateToCityAsync(city);
        }
    }
}