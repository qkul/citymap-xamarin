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
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;

namespace CityMapXamarin.Android.Views
{
    [Activity(Label = "Main Page")]
    public class MainPageView : MvxActivity<MainPageViewModel>
    {
        private Button _btnMap;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_main_page);
            InitComponets();
            AppBindings();
        }

        private void InitComponets()
        {
            _btnMap = FindViewById<Button>(Resource.Id.button_map_id);
        }

        private void AppBindings()
        {
            MvxFluentBindingDescriptionSet<MainPageView, MainPageViewModel> set = this.CreateBindingSet<MainPageView, MainPageViewModel>();//var !
            set.Bind(_btnMap).To(vm => vm.NavigateToMapAsyncCommand);
            set.Apply();
        }

    }
}