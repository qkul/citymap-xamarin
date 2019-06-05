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
using MvvmCross.Droid.Support.V7.AppCompat;

namespace CityMapXamarin.Android.Views.Activities
{
    [Activity(Label = "Setting")]
    public class SettingActivity : MvxAppCompatActivity<SettingViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_setting);
        }

    }
}