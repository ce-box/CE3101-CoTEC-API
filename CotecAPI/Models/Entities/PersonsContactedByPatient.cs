using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CotecAPI.Models.Entities
{
    public class PersonsContactedByPatient
    {
        public DateTime? MeetingDate { get; set; }


        // FKs of Many-to-Many relationships
        public string PatientDni { get; set; }
        public virtual Patient Patient { get; set; }
        
        public string ContactDni { get; set; }
        
        [JsonIgnore] 
        [IgnoreDataMember] 
        public virtual ContactedPerson Contacted { get; set; }
    }
}
