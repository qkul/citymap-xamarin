using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using CityMapXamarin.Models;
using CityMapXamarin.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;
using Newtonsoft.Json;

namespace CityMapXamarin.Android.Views.CitiesMap
{
    [Activity(Label = "CitiesMapActivity")]
    public class CitiesMapActivity : MvxActivity<CitiesMapViewModel>, IOnMapReadyCallback
    {
        private GoogleMap _googleMap;
        private IEnumerable<City> NewCities { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AppBindings();
            SetContentView(Resource.Layout.activity_map);           
            SetupMap();
        }

  
        private void AppBindings()
        {
            var set = this.CreateBindingSet<CitiesMapActivity, CitiesMapViewModel>();
            set.Bind(this).For(c=>c.NewCities).To(vm => vm.Cities);
            set.Apply();
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