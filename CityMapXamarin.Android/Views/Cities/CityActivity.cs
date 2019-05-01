using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using CityMapXamarin.Android.Views.CitiesMap;
using CityMapXamarin.Android.Views.CityDetails;
using CityMapXamarin.Infrastructure;
using CityMapXamarin.Models;
using CityMapXamarin.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityMapXamarin.Android.Views.Cities
{
    [Activity(Label = "@string/activity_cities_title")]
    public class CityActivity : AppCompatActivity
    {
        private readonly ICityService _cityService = new CityService();
        private CityAdapter _cityAdapter;
        private ProgressDialog _progressDialog;

        private IEnumerable<City> Cities { get; set; } = Enumerable.Empty<City>();

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_cities);
            _progressDialog = CreateProgressDialog();
            SetupAdapter();
            SetupRecyclerView();
            await LoadDataAsync();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.show_on_map:
                {
                    var mapActivityIntent = new Intent(this, typeof(CitiesMapActivity));
                    mapActivityIntent.PutExtra(ConstView.ExtraCities, JsonConvert.SerializeObject(Cities));
                    StartActivity(mapActivityIntent);
                    break;
                }
            }
            return true;
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.cities_map, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        private void SetupRecyclerView()
        {
            var gridCount = Resources.GetInteger(Resource.Integer.grid_count);
            var citiesLayoutManager = new GridLayoutManager(ApplicationContext, gridCount);
            var citiesRecyclerView = FindViewById<RecyclerView>(Resource.Id.recycler_view_cities_list);

            citiesRecyclerView.SetLayoutManager(citiesLayoutManager);
            citiesRecyclerView.SetAdapter(_cityAdapter);
        }

        private void SetupAdapter()
        {
            _cityAdapter = new CityAdapter();
            _cityAdapter.ItemClicked += CityAdapterOnItemClicked;
        }

        private async Task LoadDataAsync()
        {
            _progressDialog.Show();

            try
            {
                Cities = await _cityService.LoadCitiesAsync();
                _cityAdapter.Update(Cities);
            }

            finally
            {
                _progressDialog.Hide();
            }
        }

        private void CityAdapterOnItemClicked(object sender, int position)
        {
            var cityModel = Cities.ToArray()[position];

            var detailedActivityIntent = new Intent(this, typeof(CityDetailsActivity));
            detailedActivityIntent.PutExtra(ConstView.ExtraCityName, cityModel.Title);
            detailedActivityIntent.PutExtra(ConstView.ExtraCityDescription, cityModel.Description);
            detailedActivityIntent.PutExtra(ConstView.ExtraCityImageUrl, cityModel.Url);

            StartActivity(detailedActivityIntent);
        }
        private ProgressDialog CreateProgressDialog() => new ProgressDialog(this) { Indeterminate = true };

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cityAdapter.ItemClicked -= CityAdapterOnItemClicked;
            }

            base.Dispose(disposing);
        }
    }
}
