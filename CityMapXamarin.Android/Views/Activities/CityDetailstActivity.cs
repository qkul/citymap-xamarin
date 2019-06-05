
using Android.App;
using Android.OS;
using Android.Widget;
using CityMapXamarin.Android.Resources;
using CityMapXamarin.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Views;

namespace CityMapXamarin.Android.Views.CityDetails
{
    [Activity]
    public class CityDetailsActivity : MvxAppCompatActivity<CityDetailsViewModel>
    {
        private ImageView _imageViewCity;
        private TextView _textViewCity;

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