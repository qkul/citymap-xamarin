using CityMapXamarin.Infrastructure;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CityMapXamarin.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        private readonly INavigationManager _navigationManager;
        private readonly ICityService _cityService;

        public IMvxCommand NavigateToSettingAsyncCommand => new MvxAsyncCommand(DoNavigateToSettingAsync);
        public IMvxCommand NavigateToExampleAsyncCommand => new MvxAsyncCommand(DoNavigateToSettingAsync);


        public MenuViewModel(INavigationManager navigationManager, ICityService cityService)
        {
            _navigationManager = navigationManager;
            _cityService = cityService;
        }
        private async Task DoNavigateToSettingAsync()
        {
            await _navigationManager.NavigateToSettingAsync();
        }
    }
}