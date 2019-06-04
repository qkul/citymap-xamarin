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
    public class SplitRootViewModel : MvxViewModel
    {

        private readonly IMvxNavigationService _navigationService;

        public SplitRootViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            ShowInitialMenuCommand = new MvxAsyncCommand(()=> _navigationService.Navigate<SplitMasterViewModel>() );
        }

        public IMvxAsyncCommand ShowInitialMenuCommand { get; private set; }



        public override void ViewAppeared()
        {
            MvxNotifyTask.Create(async () => { await _navigationService.Navigate<SplitMasterViewModel>();});
        }

        



    }
}
