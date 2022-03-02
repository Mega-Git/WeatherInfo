using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherInfo.Services.OpenWeatherMap
{
    public class OpenWeatherMap
    {
        public static List<City> CityList { get; set; }

        public static void InitializeCitiesFromFile()
        {
            var fileName = "Services\\OpenWeatherMap\\city.list.json";
            var jsonString = File.ReadAllText(fileName);
            CityList = JsonConvert.DeserializeObject<List<City>>(jsonString);
        }
    }
}
