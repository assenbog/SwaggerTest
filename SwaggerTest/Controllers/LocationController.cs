namespace SwaggerTest.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using SwaggerTest.Repositories;

    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private LocationsRepository _locationsRepository;

        public LocationController()
        {
            _locationsRepository = new LocationsRepository();
        }

        [HttpGet]
        public List<Location> Get()
        {
            return _locationsRepository.Locations;
        }

        [HttpGet("{code}")]
        public Location Get(string code)
        {
            return _locationsRepository.Locations.FirstOrDefault(p => p.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}