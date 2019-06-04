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
        }

        public IMvxAsyncCommand ShowInitialMenuCommand { get; private set; }

        public override void ViewAppeared()
        {
            MvxNotifyTask.Create(async () =>
            {
                await ShowInitialViewModel();
            });
        }
        private async Task ShowInitialViewModel()
        {
            await _navigationService.Navigate<SplitMasterViewModel>();
        }
    }
}
