﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CityMapXamarin.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace CityMapXamarin.Android.Views
{
    [Activity(Label = "Main Page")]
    public class MainPageView : MvxActivity<MainPageViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_main_page);
        }
    }
}