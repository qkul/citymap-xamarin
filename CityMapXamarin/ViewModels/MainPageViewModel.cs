﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace CityMapXamarin.ViewModels
{
    public class MainPageViewModel : MvxViewModel
    {
        public override async Task Initialize()
        {
            await base.Initialize();
        }

        public ICommand IncrementCommand => new MvxCommand(DoIncrement);

        private void DoIncrement()
        {
            Number++;
        }

        private int _number;
        public int Number
        {
            get => _number;
            set
            {
                _number = value;
                RaisePropertyChanged(() => Number);
            }
        }
    }
}