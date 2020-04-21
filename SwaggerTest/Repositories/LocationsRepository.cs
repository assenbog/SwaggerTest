namespace SwaggerTest.Repositories
{
    using System.Collections.Generic;

    public class LocationsRepository
    {
        public LocationsRepository()
        {
            Locations = Initialise();
        }

        public List<Location> Locations { get; set; }

        #region Private Methods

        private List<Location> Initialise()
        {
            return new List<Location>
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

        #endregion Private Methods
    }
}
