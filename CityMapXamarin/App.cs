using System;
using System.Collections.Generic;
using System.Text;
using CityMapXamarin.Infrastructure;
using CityMapXamarin.Services;
using CityMapXamarin.ViewModels;
using MonkeyCache.SQLite;
using MvvmCross;
using MvvmCross.ViewModels;

namespace CityMapXamarin
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
         
            Mvx.LazyConstructAndRegisterSingleton<ICityService, CityService>();
            Mvx.LazyConstructAndRegisterSingleton<INavigationManager, NavigationManager>();
            Barrel.ApplicationId = "CityMapXamarin";
            RegisterAppStart<MainPageViewModel>();
        }
    }
}
