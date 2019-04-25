
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using FFImageLoading;
using FFImageLoading.Views;

namespace CityMapXamarin.Android.Views.CityDetails
{
    [Activity]
    public class CityDetailsActivity : AppCompatActivity
    {
        private string _cityName;
        private string _cityDescription;
        private string _cityImageUrl;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_city_details);
            LoadNavigationParameters();
            SetupToolbar();
            SetupUI();
        }


        private void LoadNavigationParameters()
        {
            var extras = Intent.Extras;

            _cityName = extras.GetString(ConstView.ExtraCityName, string.Empty);
            _cityDescription = extras.GetString(ConstView.ExtraCityDescription, string.Empty);
            _cityImageUrl = extras.GetString(ConstView.ExtraCityImageUrl, string.Empty);
        }

        private void SetupToolbar()
        {
            var contraction = SupportActionBar;     
            contraction.SetDisplayHomeAsUpEnabled(true);
            contraction.SetDisplayShowHomeEnabled(true);
        
            contraction.Title = _cityName;
        }
        public override bool OnSupportNavigateUp()
        {
            OnBackPressed();
            return true;
        }

        private void SetupUI()
        {
            var descriptionTextView = FindViewById<TextView>(Resource.Id.text_view_city_details);
            var photoImageView = FindViewById<ImageViewAsync>(Resource.Id.image_city_details);

            descriptionTextView.Text = _cityDescription;

            ImageService.Instance
                .LoadUrl(_cityImageUrl)
                .Into(photoImageView);
        }
    }
}