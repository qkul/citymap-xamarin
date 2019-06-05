using CityMapXamarin.Infrastructure;
using CityMapXamarin.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityMapXamarin.ViewModels
{
    public class MainPageViewModel : MvxViewModel
    {
        private readonly INavigationManager _navigationManager;
        private readonly ICityService _cityService;
        private readonly IMvxNavigationService _navigationService;

        private IEnumerable<City> _cities;
        public IMvxAsyncCommand ShowSplitCommand { get; }
        public  IMvxCommand NavigateToMapAsyncCommand  => new MvxAsyncCommand(DoNavigateToMapAsync);      
        public IMvxCommand NavigateToCityAsyncCommand => new MvxAsyncCommand<City>(DoNavigateToCityAsync);
        public IMvxCommand NavigateToMenuAsyncCommand => new MvxAsyncCommand(DoNavigateToMenuAsync);
        public IMvxAsyncCommand ShowInitialMenuCommand { get; private set; }

    
    

        public MainPageViewModel(IMvxNavigationService navigationService,INavigationManager navigationManager, ICityService cityService)
        {
            _navigationService = navigationService;
            _navigationManager = navigationManager;
            _cityService = cityService;
            ShowInitialMenuCommand = new MvxAsyncCommand(ShowInitialViewModel);
        }
        public override void ViewAppeared()
        {
            MvxNotifyTask.Create(async () =>
            {
                await ShowInitialViewModel();
            });
        }
        private async Task ShowInitialViewModel()
        {
            await _navigationService.Navigate<SplitMasterViewModel>();
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


        private async Task DoNavigateToMenuAsync()
        {
            await _navigationManager.NavigateToMenu();
        }
        private async Task DoNavigateToCityAsync(City city)
        {
            await _navigationManager.NavigateToCityAsync(city);
        }
    }
}