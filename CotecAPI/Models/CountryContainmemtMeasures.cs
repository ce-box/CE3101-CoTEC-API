namespace CotecAPI.Models
{
    public class CountryContainmemtMeasures
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }


        // FK
        public string CountryCode { get; set; }
        public virtual Country Country { get; set; }

        public int MeasureId { get; set; }
        public virtual SanitaryMeasure Measure { get; set; }
    }
}
