
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using CityMapXamarin.Android.Resources;
using CityMapXamarin.Android.Views.CitiesMap;
using CityMapXamarin.ViewModels;
using FFImageLoading;
using FFImageLoading.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;
using Newtonsoft.Json;

namespace CityMapXamarin.Android.Views.CityDetails
{
    [Activity]
    public class CityDetailsActivity : MvxActivity<CityDetailsViewModel>
    {
        private ImageView _imageViewCity;
        private TextView _textViewCity;

        //private string _cityName;
        
        //private string _cityDescription;
        //private string _cityImageUrl;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_city_details);
            InitComponets();
            AppBindings();
        }

        private void InitComponets()
        {
            _imageViewCity = FindViewById<ImageView>(Resource.Id.image_city_details);
            _textViewCity = FindViewById<TextView>(Resource.Id.text_view_city_details);
       
        }

        private void AppBindings()
        {
            var set = this.CreateBindingSet<CityDetailsActivity, CityDetailsViewModel>();
            set.Bind(_imageViewCity).For(x => x.Drawable).To(vm => vm.City.Url).WithConversion<ImagePathToDrawableConverter>();
            set.Bind(_textViewCity).For(x=>x.Text).To(vm=>vm.City.Description);
            set.Apply();
        }
    }
}