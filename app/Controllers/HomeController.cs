﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using app.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public async Task<IActionResult> WeatherForecast()
{
    List<WeatherForecast> reservationList = new List<WeatherForecast>();
    using (var httpClient = new HttpClient())
    {
        using (var response = await httpClient.GetAsync("http://weather-api/weatherforecast"))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            reservationList = JsonConvert.DeserializeObject<List<WeatherForecast>>(apiResponse);
        }
    }
    return View(reservationList);
}
    }
}
