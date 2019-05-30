using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CityMapXamarin.Infrastructure;
using CityMapXamarin.Services;
using CityMapXamarin.ViewModels;
using MonkeyCache.SQLite;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace CityMapXamarin
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.LazyConstructAndRegisterSingleton<ICityService, CityService>();
            Mvx.LazyConstructAndRegisterSingleton<INavigationManager, NavigationManager>();
            Barrel.ApplicationId = "CityMapXamarin";
            RegisterAppStart<MainPageViewModel>();
        }

        public override Task Startup()
        {
            return base.Startup();
        }

        public override void Reset()
        {
            base.Reset();
        }

    }
}
