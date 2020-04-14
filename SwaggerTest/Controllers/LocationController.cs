namespace SwaggerTest.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly List<Location> _locations;

        public LocationController()
        {
            _locations = new List<Location>
            {
                new Location { Code = "Lon", City = "London", Country = "U.K." },
                new Location { Code = "Lon", City = "London", Country = "U.K." },
                new Location { Code = "Rom", City = "Rome", Country = "Italy" },
                new Location { Code = "Mad", City = "Madrid", Country = "Spain" },
                new Location { Code = "Ber", City = "Berlin", Country = "Germany" },
                new Location { Code = "Buc", City = "Buchares", Country = "Romania" },
                new Location { Code = "Sof", City = "Sofia", Country = "Sofia" }
            };
        }

        [HttpGet]
        public List<Location> Get()
        {
            return _locations;
        }

        [HttpGet("{code}")]
        public Location Get(string code)
        {
            return _locations.FirstOrDefault(p => p.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}