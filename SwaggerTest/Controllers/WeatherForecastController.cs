namespace SwaggerTest.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private List<WeatherForecast> _weatherForecasts;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _weatherForecasts = Initialise();
        }

        [HttpGet]
        public List<WeatherForecast> Get()
        {
            return _weatherForecasts;
        }

        [HttpGet("{id}")]
        public WeatherForecast Get(int index)
        {
            return _weatherForecasts[index];
        }

        [HttpGet("{day}/{month}/{year}")]
        public WeatherForecast Get(int day, int month, int year)
        {
            return _weatherForecasts.FirstOrDefault(p => p.Date == new DateTime(year, month, day));
        }

        [HttpDelete("{id}")]
        public void Delete(int index)
        {
            _weatherForecasts.RemoveAt(index);
        }

        [HttpPost("{day}/{month}/{year}/{tempC}/{weatherType}")]
        public WeatherForecast Create(int day, int month, int year, int tempC, string weatherType)
        {
            var forecast = new WeatherForecast
            {
                Date = new DateTime(year, month, day),
                TemperatureC = tempC,
                Summary = weatherType
            };

            _weatherForecasts.Add(forecast);

            return forecast;
        }

        [HttpPost]
        public WeatherForecast Create(WeatherForecast forecast)
        {
            _weatherForecasts.Add(forecast);

            return forecast;
        }

        [HttpPut("{day}/{month}/{year}/{tempC}/{weatherType}")]
        public void Update(int day, int month, int year, int tempC, string weatherType)
        {
            var forecast = _weatherForecasts.FirstOrDefault(p => p.Date == new DateTime(year, month, day));

            forecast.TemperatureC = tempC;
            forecast.Summary = weatherType;
        }

        #region Private Methods

        private List<WeatherForecast> Initialise()
        {
            var rng = new Random();
            var forecasts = new List<WeatherForecast>() {new WeatherForecast
            {
                Date = DateTime.Now.Date,
                TemperatureC = 22,
                Summary = Summaries[6]
            } };
            forecasts.AddRange(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.Date.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }));

            return forecasts;
        }

        #endregion Private Methods
    }
}
