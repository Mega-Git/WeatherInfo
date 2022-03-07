using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherInfo.Services.OpenWeatherMap.Weather;
using dotenv.net;
using dotenv.net.Utilities;

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
        public static WeatherReport GetReportByCityId(string cityId)
        {
            DotEnv.Load();
            var client = new HttpClient();
            var API_key = EnvReader.GetStringValue("API_KEY");
            string city_id = cityId;
            string units = "metric";
            string URL = $"api.openweathermap.org/data/2.5/weather?id={city_id}&appid={API_key}&units={units}";
            var response = client.GetAsync(URL).Result;
            var report = JsonConvert.DeserializeObject<WeatherReport>(response.Content.ReadAsStringAsync().Result);
            return report;
        }
    }
}
