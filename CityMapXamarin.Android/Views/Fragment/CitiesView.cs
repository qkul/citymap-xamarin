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
using CityMapXamarin.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace CityMapXamarin.Android.Views.Fragment
{
    [MvxFragmentPresentation(typeof(SplitRootViewModel), Resource.Id.split_content_frame)]
    [Register(nameof(CitiesView))]
    public class CitiesView : BaseView<CitiesViewModel>
    {
        protected override int FragmentId => Resource.Layout.activity_setting;

  
    }
}