using CityMapXamarin.Infrastructure;
using CityMapXamarin.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CityMapXamarin.ViewModels
{
    public class MainPageViewModel : MvxViewModel
    {
        private readonly INavigationManager _navigationManager;
        private readonly ICityService _cityService;

        private IEnumerable<City> _cities;
        public IMvxAsyncCommand ShowSplitCommand { get; }
        public IMvxCommand NavigateToMapAsyncCommand => new MvxAsyncCommand(DoNavigateToMapAsync);

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
        //
        private IMvxAsyncCommand _refreshCommand;
        public IMvxAsyncCommand RefreshCommand
            => _refreshCommand ?? (_refreshCommand = new MvxAsyncCommand(ExecuteRefreshCommand));

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private async Task ExecuteRefreshCommand()
        {
            IsBusy = true;
            Cities = await _cityService.LoadCitiesAsync();
            IsBusy = false;
        }
        //
        public override async void ViewCreated()
        {
            IsBusy = true;
            base.ViewCreated();
            Cities = await _cityService.LoadCitiesAsync();
            IsBusy = false;
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