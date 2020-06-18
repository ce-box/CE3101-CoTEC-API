using System;

namespace CotecAPI.Models
{
    public class PersonsContactedByPatient
    {
        public DateTime? MeetingDate { get; set; }


        // FKs of Many-to-Many relationships
        public string PatientDni { get; set; }
        public virtual Patient Patient { get; set; }
        
        public string ContactDni { get; set; }
        public virtual ContactedPerson Contacted { get; set; }
    }
}
