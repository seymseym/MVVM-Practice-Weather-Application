using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatheApp.Model;
using WeatheApp.ViewModel.Helpers;

namespace WeatheApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        public SearchCommand SearchCommand { get; set; }
        public ObservableCollection<City> Cities { get; set; }

        public WeatherVM()
        {
            SearchCommand = new SearchCommand(this);
            Cities = new ObservableCollection<City>();
        }

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
                selectedCity = value;
                if (selectedCity != null)
                {
                    OnPropertyChanged("SelectedCity");
                    getCurrentConditions();
                }
            }
        }

        public async void getCurrentConditions()
        {
            Query = string.Empty;
            CurrentConditions = await AccuWeatherHelper.GetCurrentConditions(selectedCity.Key);
            Cities.Clear();
        }

        public async void makeQuery()
        {
            var cities = await AccuWeatherHelper.GetCities(Query);
            Cities.Clear();

            foreach (var city in cities)
            {
                Cities.Add(city);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
