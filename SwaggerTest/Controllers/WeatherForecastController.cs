namespace SwaggerTest.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using SwaggerTest.Repositories;

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private WeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _weatherForecastRepository = new WeatherForecastRepository();
        }

        [HttpGet]
        public List<WeatherForecast> Get()
        {
            return _weatherForecastRepository.WeatherForecasts;
        }

        [HttpGet("{id}")]
        public WeatherForecast Get(int index)
        {
            return _weatherForecastRepository.WeatherForecasts[index];
        }

        [HttpGet("{location}/forecasts")]
        public List<WeatherForecast> Get(string location)
        {
            return _weatherForecastRepository.WeatherForecasts.Where(p => p.ForecastLocation.Code.Equals(location, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        [HttpGet("{day}/{month}/{year}")]
        public WeatherForecast Get(int day, int month, int year)
        {
            return _weatherForecastRepository.WeatherForecasts.FirstOrDefault(p => p.Date == new DateTime(year, month, day));
        }

        [HttpDelete("{id}")]
        public void Delete(int index)
        {
            _weatherForecastRepository.WeatherForecasts.RemoveAt(index);
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

            _weatherForecastRepository.WeatherForecasts.Add(forecast);

            return forecast;
        }

        [HttpPost]
        public WeatherForecast Create(WeatherForecast forecast)
        {
            _weatherForecastRepository.WeatherForecasts.Add(forecast);

            return forecast;
        }

        [HttpPut("{day}/{month}/{year}/{tempC}/{weatherType}")]
        public void Update(int day, int month, int year, int tempC, string weatherType)
        {
            var forecast = _weatherForecastRepository.WeatherForecasts.FirstOrDefault(p => p.Date == new DateTime(year, month, day));

            forecast.TemperatureC = tempC;
            forecast.Summary = weatherType;
        }
    }
}
