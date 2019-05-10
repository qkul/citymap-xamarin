using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CityMapXamarin.Android.Views.Cities;
using CityMapXamarin.Android.Views.CitiesMap;
using MvvmCross.Platforms.Android.Views;

namespace CityMapXamarin.Android
{
    [Activity(MainLauncher = true, Icon = "@mipmap/ic_launcher_round", Theme = "@style/SplashTheme")]
    public class SplashScreenActivity : MvxSplashScreenActivity
    {
        //protected override void OnCreate(Bundle savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);
        //    new CityMapXamarin.App().Initialize();
        //    StartActivity(new Intent(this, typeof(MainPageView)));
        //    Finish();
        //}
        public SplashScreenActivity() : base(Resource.Layout.activity_splash_screen)
        {
        }
    }
}