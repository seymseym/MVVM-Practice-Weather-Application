using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatheApp.Model;

namespace WeatheApp.ViewModel
{
    class WeatherVM : INotifyPropertyChanged
    {
        private string query;

        public string Query
        {
            get { return query; }
            set 
            {
                query = value;
                OnPropertyChanged("Query");
            }
        }

        private CurrentConditions currentconditions;

        public CurrentConditions CurrentConditions
        {
            get { return currentconditions; }
            set 
            {
                currentconditions = value;
                OnPropertyChanged("CurrentConditions");
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get => selectedCity;
            set
            {
                OnPropertyChanged("SelectedCity");
                selectedCity = value;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged (string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
