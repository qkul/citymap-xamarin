using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Support.V4.App;
using CityMapXamarin.Models;
using CityMapXamarin.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Views;
using System.Collections.Generic;

namespace CityMapXamarin.Android.Views.CitiesMap
{
    [Activity(Label = "Map", Theme= "@style/AppThemeActionBar")]
    public class CitiesMapActivity : MvxAppCompatActivity<CitiesMapViewModel>, IOnMapReadyCallback
    {
        private GoogleMap _googleMap;
        public IEnumerable<City> NewCities { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AppBindings();    
            SetContentView(Resource.Layout.activity_map);
            SetupToolbar();
            SetupMap();
        }
      
        public void OnMapReady(GoogleMap googleMap)
        {
            _googleMap = googleMap;

            foreach (var city in NewCities)
            {
                var cityCoordinates = new LatLng(city.Latitude, city.Longitude);

                googleMap.AddMarker(new MarkerOptions()
                    .SetPosition(cityCoordinates)
                    .SetTitle(city.Title));
            }
        }
        public override bool OnSupportNavigateUp()
        {
            OnBackPressed();
            return true;
        }
        private void SetupToolbar()
        {
            var contraction = SupportActionBar;
            contraction.SetDisplayHomeAsUpEnabled(true);
            contraction.SetDisplayShowHomeEnabled(true);
        }
       
        private void AppBindings()
        {
            var set = this.CreateBindingSet<CitiesMapActivity, CitiesMapViewModel>();
            set.Bind(this).For(c=>c.NewCities).To(vm => vm.Cities);
            set.Apply();
        }

        
        private void SetupMap()
        {
            //var mapFragment = (SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map);
            //mapFragment.GetMapAsync(this);
            if (_googleMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }
    }
}