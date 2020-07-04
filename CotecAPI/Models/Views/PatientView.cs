namespace CotecAPI.Models.Views
{
    public class PatientView
    {
        public string Dni { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Hospital { get; set; }
        public bool Hospitalized { get; set; }
        public bool ICU { get; set; }
        public string Status { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }
}