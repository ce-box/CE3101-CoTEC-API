namespace CotecAPI.Models
{
    public class ContactedPerson
    {
        public string Dni { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DoB { get; set; }
        public string Email { get; set; }

        // FK
        public string Region { get; set; }
        public string Country { get; set; }
        public virtual Region HRegion { get; set; }

    }
}
