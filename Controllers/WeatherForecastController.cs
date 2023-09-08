﻿using LearnAspDotNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnAspDotNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public JsonResult Get()
        {
            var data = new { status = "Cold", message="It is cold outside." };
            var json = new JsonResult(data);
            return json;
        }

        [HttpPost(Name = "PostWeatherForecast")]
        public JsonResult Post(WeatherBody weatherBody)
        {
            var data = new { status = weatherBody.Status, message = weatherBody.Message };
            var json = new JsonResult(data);
            return json;
        }
    }
}
