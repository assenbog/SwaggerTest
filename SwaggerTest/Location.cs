namespace SwaggerTest
{
    using System.ComponentModel.DataAnnotations;

    public class Location
    {
        [Key]
        public int ID { get; set; }

        public string Code { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
