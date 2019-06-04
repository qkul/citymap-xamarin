using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace CityMapXamarin.ViewModels
{
    public class SplitMasterViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public SplitMasterViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            ShowRootViewModel = new MvxAsyncCommand(() => _navigationService.Navigate<MainPageViewModel>());
        }
        public IMvxAsyncCommand ShowRootViewModel { get; private set; }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
        }
    }
}
