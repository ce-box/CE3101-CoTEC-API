using System.Collections.Generic;

namespace CotecAPI.Models
{
    public class Region
    {
        public string Name { get; set; }
       

        // FK references Country.Code
        public string CountryCode { get; set; }
        public virtual Country Country { get; set; }

        // One-to-many relationships
        public virtual ICollection<Hospital> Hospitals { get; set; }
    }
}