using Android.App;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Widget;
using CityMapXamarin.Android.Views.Cities;
using CityMapXamarin.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;

namespace CityMapXamarin.Android.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "Cities")]
    public class MainPageView : MvxAppCompatActivity <MainPageViewModel>
    {
        
        private MvxRecyclerView _recyclerView;
        private Button _btnMap;
        private Button _btnMenu;
        private CityAdapter _adapter;
        public DrawerLayout drawerLayout { get; set; }

     
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _adapter = new CityAdapter((IMvxAndroidBindingContext)BindingContext);
            SetContentView(Resource.Layout.activity_cities);
            InitComponets();
            if (bundle == null)
            {
                ViewModel.ShowInitialMenuCommand.Execute();
            }
            AppBindings();
        }
      
           
        public override void OnBackPressed()
        {
            if (drawerLayout != null && drawerLayout.IsDrawerOpen(GravityCompat.Start))
                drawerLayout.CloseDrawers();
            else
                base.OnBackPressed();
        }
        private void InitComponets()
        {
            var gridCount = Resources.GetInteger(Resource.Integer.grid_count);
            var citiesLayoutManager = new GridLayoutManager(ApplicationContext, gridCount);

            _recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.recycler_view_cities_list);
            _recyclerView.SetLayoutManager(citiesLayoutManager);
            _recyclerView.Adapter = _adapter;
            _btnMap = FindViewById<Button>(Resource.Id.button_map_id);
            _btnMenu = FindViewById<Button>(Resource.Id.button_menu);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
        }

        private void AppBindings()
        {
            var set = this.CreateBindingSet<MainPageView, MainPageViewModel>();
            set.Bind(_adapter).For(b => b.CityClick).To(vm => vm.NavigateToCityAsyncCommand);
            set.Bind(_adapter).For(b => b.ItemsSource).To(vm => vm.Cities);
            set.Bind(_btnMap).To(vm => vm.NavigateToMapAsyncCommand);
            set.Bind(_btnMenu).To(vm => vm.NavigateToMenuAsyncCommand);
            set.Apply();
        }

    }
}