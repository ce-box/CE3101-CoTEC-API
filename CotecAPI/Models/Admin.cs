namespace CotecAPI.Models
{
    public class Admin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }


        // FK, references Country.Code
        public string CountryCode { get; set; }
        public virtual Country Country { get; set; }
    }
}