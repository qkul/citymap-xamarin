using CityMapXamarin.Models;
using MvvmCross.ViewModels;
using System.Collections.Generic;

namespace CityMapXamarin.ViewModels
{
    public class CitiesMapViewModel : MvxViewModel<IEnumerable<City>>
    {
        private IEnumerable<City> _cities;

        public IEnumerable<City> Cities
        {
            get => _cities;
            set
            {
                _cities = value;
                RaisePropertyChanged(() => Cities);
            }
        }

        public override void Prepare(IEnumerable<City> parameter)
        {
            _cities = parameter;
        }
    }
}
