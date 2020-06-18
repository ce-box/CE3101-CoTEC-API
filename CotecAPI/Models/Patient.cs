namespace CotecAPI.Models
{
    public class Patient
    {
        public string Dni { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string BoD { get; set; }
        public bool Hospitalized { get; set; }
        public bool ICU { get; set; }


        // FK
        public int Status { get; set; }
        public virtual PatientStatus PatientStatus { get; set; }
        public int Hospital_id { get; set; }
        public virtual Hospital Hospital { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public virtual Region HRegion { get; set; }
    }
}
