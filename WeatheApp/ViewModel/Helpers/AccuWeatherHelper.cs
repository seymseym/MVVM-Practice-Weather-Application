﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatheApp.Model;

namespace WeatheApp.ViewModel.Helpers
{
    public class AccuWeatherHelper
    {
        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string API_KEY = "zGit1Qlb8Xu5ArMRlNAsI0Z3DjPV0r2C";
        public const string AUTOSEARCH_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CURRENTCONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";

        public List<City> GetCities(string query)
        {
            List<City> cities = new List<City>();
            string url = BASE_URL + string.Format(AUTOSEARCH_ENDPOINT, API_KEY, query);

            using(HttpClient client = new HttpClient)
            {
                string response = 
            }
        }
    }
}