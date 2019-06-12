using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using CityMapXamarin.Android.Views.Cities;
using CityMapXamarin.Android.Views.Fragment;
using CityMapXamarin.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace CityMapXamarin.Android.Views
{
    [MvxFragmentPresentation(typeof(SplitRootViewModel), Resource.Id.split_content_frame)]
    [Register(nameof(MainPageView))]
    public class MainPageView : BaseView<MainPageViewModel>
    {
        protected override int FragmentId => Resource.Layout.activity_cities;
        private MvxRecyclerView _recyclerView;
        private Button _btnMap;
        private CityAdapter _adapter;       

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            ParentActivity.SupportActionBar.Title = "Cities";
            InitComponents(view);
            AppBindings();  
            return view;
        }
  

        private void InitComponents(View view)
        {
            _adapter = new CityAdapter((IMvxAndroidBindingContext)BindingContext);

            var gridCount = Resources.GetInteger(Resource.Integer.grid_count);
            var citiesLayoutManager = new GridLayoutManager(Context, gridCount);

            _recyclerView = view.FindViewById<MvxRecyclerView>(Resource.Id.recycler_view_cities_list);
            _recyclerView.SetLayoutManager(citiesLayoutManager);
            _recyclerView.Adapter = _adapter;
            _btnMap = view.FindViewById<Button>(Resource.Id.button_map_id);
        }

        private void AppBindings()
        {
            var owner = this as IMvxBindingContextOwner;
            var set = owner.CreateBindingSet<IMvxBindingContextOwner, MainPageViewModel>();
            set.Bind(_adapter).For(b => b.CityClick).To(vm => vm.NavigateToCityAsyncCommand);
            set.Bind(_adapter).For(b => b.ItemsSource).To(vm => vm.Cities);
            set.Bind(_btnMap).To(vm => vm.NavigateToMapAsyncCommand);
            set.Apply();
        }
    }
}