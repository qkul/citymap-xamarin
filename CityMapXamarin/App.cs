using System;
using System.Collections.Generic;
using System.Text;
using CityMapXamarin.ViewModels;
using MonkeyCache.SQLite;
using MvvmCross.ViewModels;

namespace CityMapXamarin
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Barrel.ApplicationId = "CityMapXamarin";
            RegisterAppStart<MainPageViewModel>();
        }
    }
}
