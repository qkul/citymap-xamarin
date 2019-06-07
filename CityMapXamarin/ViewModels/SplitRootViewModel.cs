using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace CityMapXamarin.ViewModels
{
    public class SplitRootViewModel : MvxViewModel
    {

        private readonly IMvxNavigationService _navigationService;

        public SplitRootViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            ShowInitialMenuCommand = new MvxAsyncCommand(ShowInitialViewModel);
            ShowCitiesCommand = new MvxAsyncCommand(ShowCitiesViewModel);
        }

        public IMvxAsyncCommand ShowInitialMenuCommand { get; private set; }
        public IMvxAsyncCommand ShowCitiesCommand { get; private set; }


        public override void ViewAppeared()
        {
            MvxNotifyTask.Create(async () =>
            {
                await ShowInitialViewModel();
                await ShowCitiesViewModel();
            });
        }

        private async Task ShowCitiesViewModel()
        {
            await _navigationService.Navigate<CitiesViewModel>();

        }

        private async Task ShowInitialViewModel()
        {
            await _navigationService.Navigate<SplitMasterViewModel>();
        }
    }
}
