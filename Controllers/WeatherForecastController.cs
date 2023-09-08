using LearnAspDotNet.Models;
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
            /* READ */
            var data = new { status = "Cold", message="It is cold outside." };
            var json = new JsonResult(data);
            return json;
        }

        [HttpPost(Name = "PostWeatherForecast")]
        public JsonResult Post(WeatherBody weatherBody)
        {
            /* CREATE */
            var data = new { status = weatherBody.Status, message = weatherBody.Message };
            var json = new JsonResult(data);
            return json;
        }

        [HttpDelete(Name = "DeleteWeatherForecast")]
        public JsonResult Delete(long id)
        {
            /* DELETE */
            var data = new { id = id, message = "Deleted weather forecast" };
            var json = new JsonResult(data);
            return json;
        }

        [HttpPatch(Name ="PatchWeatherForecast")]
        public JsonResult Patch(WeatherBody weatherBody)
        {
            /* UPDATE */
            var weather_data = new { id = weatherBody.id, status = weatherBody.Status, message = weatherBody.Message };
            var data = new { body = weather_data, message = "Updated weather forecast" };
            var json = new JsonResult(data);
            return json;
        }
    }
}
