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
using CityMapXamarin.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;

namespace CityMapXamarin.Android.Views
{
    [Activity(Label = "Cities")]
    public class MainPageView : MvxActivity<MainPageViewModel>
    {
        private MvxRecyclerView _recyclerView;
        private Button _btnMap;
        private CityAdapter _adapter;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _adapter = new CityAdapter((IMvxAndroidBindingContext)BindingContext);
            SetContentView(Resource.Layout.activity_cities);
            InitComponets();
            AppBindings();
        }

        private void InitComponets()
        {
            _recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.recycler_view_cities_list);
            _recyclerView.Adapter = _adapter;
            _btnMap = FindViewById<Button>(Resource.Id.button_map_id);
        }

        private void AppBindings()
        {
            MvxFluentBindingDescriptionSet<MainPageView, MainPageViewModel> set = this.CreateBindingSet<MainPageView, MainPageViewModel>();//var !           
            set.Bind(_adapter).For(b => b.CityClick).To(vm => vm.NavigateToCityAsyncCommand);
            set.Bind(_adapter).For(b => b.ItemsSource).To(vm => vm.Cities);
            set.Bind(_btnMap).To(vm => vm.NavigateToMapAsyncCommand);
            set.Apply();
        }

    }
}