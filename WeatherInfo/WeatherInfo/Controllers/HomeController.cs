using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WeatherInfo.Models;
using WeatherInfo.Services.OpenWeatherMap;

namespace WeatherInfo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(WeatherCityListModel model)
        {
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Weather(WeatherReportModel model)
        {
            return View(model);
        }

        public IActionResult CheckWeather(City city)
        {
            var cityId = city.Id.ToString();
            var report = OpenWeatherMap.GetReportByCityId(cityId);
            var model = new WeatherReportModel
            {
                Report = report
            };
            return View("Weather", model);
        }

        public IActionResult Country()
        {
            var cityList = OpenWeatherMap.CityList;
            var model = new CountryListModel
            {
                CountryList = cityList.GroupBy(x => x.Country).Select(x => x.First().Country).Distinct().ToList()
            };

            return View(model);
        }

        public IActionResult CountrySelect(string country)
        {
            var cityList = OpenWeatherMap.CityList;
            var model = new WeatherCityListModel
            {
                Cities = cityList.Where(x => x.Country == country).GroupBy(x => x.Name).Select(x => x.FirstOrDefault()).OrderBy(x => x.Name).ToList()
            };

            return View("Index", model);
        }
    }
}
