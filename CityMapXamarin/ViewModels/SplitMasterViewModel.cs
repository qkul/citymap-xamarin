using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityMapXamarin.ViewModels
{
    public class SplitMasterViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public SplitMasterViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            ShowRootViewModel = new MvxAsyncCommand(() => _navigationService.Navigate<MainPageViewModel>());
        }

        public string PaneText => "Text for the Master Pane";


        public IMvxAsyncCommand ShowRootViewModel { get; private set; }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
        }
    }
}
