namespace SwaggerTest.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WeatherForecastRepository
    {
        public WeatherForecastRepository()
        {
            WeatherForecasts = Initialise();
        }

        public List<Location> Locations { get; private set; }

        public List<WeatherForecast> WeatherForecasts { get; set; }

        #region Private Methods

        private List<WeatherForecast> Initialise()
        {
            var summaries = new Dictionary<int,string>
            {
                { -10,  "Freezing"}, { 5, "Chilly"}, {10, "Cool" }, {15, "Mild" }, { 18, "Warm" }, {30, "Hot" }, {40, "Scorching" }
            };

            var now = DateTime.Now.Date;

            var sevenDays = new List<DateTime> { now.Date, now.AddDays(1), now.AddDays(2), now.AddDays(3), now.AddDays(4), now.AddDays(5), now.AddDays(6) };

            Locations = new LocationsRepository().Locations;

            var rng = new Random();

            var forecasts = new List<WeatherForecast>();

            foreach (var location in Locations)
            {
                foreach(var day in sevenDays)
                {
                    var summaryIndex = rng.Next(0, 6);
                    forecasts.Add(new WeatherForecast { Date = day, ForecastLocation = location, TemperatureC = summaries.Keys.ToArray()[summaryIndex], Summary = summaries.Values.ToArray()[summaryIndex] });
                }
            }

            return forecasts;
        }

        #endregion Private Methods
    }
}
