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
using Newtonsoft.Json;

namespace CityMapXamarin.Android.Views.CitiesMap
{
    [Activity(Label = "CitiesMapActivity")]
    public class CitiesMapActivity : FragmentActivity, IOnMapReadyCallback
    {
        private IEnumerable<City> Cities { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_map);

            LoadNavigationParameters();

            SetupMap();
        }

        private void LoadNavigationParameters()
        {
            var citiesSerialized = Intent.GetStringExtra(ConstView.ExtraCities);
            Cities = JsonConvert.DeserializeObject<IEnumerable<City>>(citiesSerialized);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            foreach (var city in Cities)
            {
                var cityCoordinates = new LatLng(city.Latitude, city.Longitude);

                googleMap.AddMarker(new MarkerOptions()
                    .SetPosition(cityCoordinates)
                    .SetTitle(city.Title));
            }
        }
        private void SetupMap()
        {
            var mapFragment = (SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);
        }
    }
}