using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityMapXamarin.ViewModels
{
    public class SplitMasterViewModel : MvxNavigationViewModel
    {
        public SplitMasterViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
      

            ShowRootViewModel = new MvxAsyncCommand(async () => await NavigationService.Navigate<MainPageViewModel>());
        }

        public string PaneText => "Text for the Master Pane";


        public IMvxAsyncCommand ShowRootViewModel { get; private set; }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
        }
    }
}
