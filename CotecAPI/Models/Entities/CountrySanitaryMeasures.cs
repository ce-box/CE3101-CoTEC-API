using System;

namespace CotecAPI.Models.Entities
{
    public class CountrySanitaryMeasures
    {
        public DateTime StartDate { get; set; } // Format: yyyy-mm-dd
        public DateTime EndDate { get; set; } // Format: yyyy-mm-dd
        public string Status { get; set; } // Status in ACTIVE or INACTIVE 


        // FKs of Many-to-Many relationships
        public string CountryCode { get; set; }
        public virtual Country Country { get; set; } 
        
        public int MeasureId { get; set; }
        public virtual SanitaryMeasure Measure { get; set; }


    }
}