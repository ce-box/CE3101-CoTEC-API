namespace CotecAPI.Models
{
    public class CountrySanitaryMeasures
    {
        public string StartDate { get; set; } // Format: yyyy-mm-dd
        public string EndDate { get; set; } // Format: yyyy-mm-dd
        public string Status { get; set; } // Status in ACTIVE or INACTIVE 


        // FKs of Many-to-Many relationships
        public string CountryCode { get; set; }
        public virtual Country Country { get; set; } 
        
        public int MeasureId { get; set; }
        public virtual SanitaryMeasure Measure { get; set; }


    }
}