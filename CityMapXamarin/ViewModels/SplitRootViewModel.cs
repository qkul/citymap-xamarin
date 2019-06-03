using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CityMapXamarin.Infrastructure;
using MvvmCross.Binding.Combiners;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace CityMapXamarin.ViewModels
{
    public class SplitRootViewModel : MvxNavigationViewModel
    {
        public SplitRootViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
            ShowInitialMenuCommand = new MvxAsyncCommand(ShowInitialViewModel);
        
        }

        public IMvxAsyncCommand ShowInitialMenuCommand { get; private set; }

      

        public override void ViewAppeared()
        {
            MvxNotifyTask.Create(async () => {
                await ShowInitialViewModel();

            });
        }

        private async Task ShowInitialViewModel()
        {
            await NavigationService.Navigate<SplitMasterViewModel>();
        }

     
    }
}
