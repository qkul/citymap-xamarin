using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CityMapXamarin.Models;
using MvvmCross.ViewModels;

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
