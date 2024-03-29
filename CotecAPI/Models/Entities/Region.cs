using System.Collections.Generic;

namespace CotecAPI.Models.Entities
{
    public class Region
    {
        public string Name { get; set; }
       

        // FK references Country.Code
        public string CountryCode { get; set; }
        public virtual Country Country { get; set; }


        // One-to-many relationships
        public virtual ICollection<Hospital> Hospitals { get; set; }
        public virtual ICollection<ContactedPerson> ContactedPersons { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}