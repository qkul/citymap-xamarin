using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace CityMapXamarin.ViewModels
{
    public class SettingViewModel : MvxNavigationViewModel
    {
        public SettingViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(
            logProvider, navigationService)
        {
        }
    }
}
