using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using CityMapXamarin.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace CityMapXamarin.Android.Views
{
    public class SplitRootView : MvxAppCompatActivity<SplitRootViewModel>
    {
        public DrawerLayout drawerLayout { get; set; }

        public SplitRootView()
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.SplitRootView);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            if (bundle == null)
            {
                ViewModel.ShowInitialMenuCommand.Execute();
                ViewModel.ShowDetailCommand.Execute();
            }
        }
        public override void OnBackPressed()
        {
            if (drawerLayout != null && drawerLayout.IsDrawerOpen(GravityCompat.Start))
                drawerLayout.CloseDrawers();
            else
                base.OnBackPressed();
        }
    }
}