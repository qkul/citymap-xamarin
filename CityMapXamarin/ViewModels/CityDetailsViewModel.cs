using System;
using System.Collections.Generic;
using System.Text;
using CityMapXamarin.Models;
using MvvmCross.ViewModels;

namespace CityMapXamarin.ViewModels
{
    public class CityDetailsViewModel : MvxViewModel<City>
    {
        City _city;

        public City City
        {
            get => _city;
            set
            {
                _city = value;
                RaisePropertyChanged(() => City);
            }
        }

        public override void Prepare(City parameter)
        {
            _city = parameter;
        }
    }
}
