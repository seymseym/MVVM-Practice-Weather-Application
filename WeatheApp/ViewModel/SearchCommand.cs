﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatheApp.ViewModel
{
    public class SearchCommand : ICommand
    {
        public WeatherVM VM { get; set; }
        public event EventHandler CanExecuteChanged;

        public SearchCommand(WeatherVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.makeQuery();
        }
    }
}
