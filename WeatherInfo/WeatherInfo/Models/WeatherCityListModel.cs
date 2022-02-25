using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherInfo.Services.OpenWeatherMap;

namespace WeatherInfo.Models
{
    public class WeatherCityListModel
    {
        public List<City> Cities { get; set; }
    }
}
