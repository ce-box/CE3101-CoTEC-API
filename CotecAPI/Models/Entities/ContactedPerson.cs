using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CotecAPI.Models.Entities
{
    public class ContactedPerson
    {
        public string Dni { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public string Email { get; set; }

        public string Address { get; set;}

        // One-to-many relationship
        public string Region { get; set; }
        public string Country { get; set; }
        public virtual Region PersonRegion { get; set; }

        
        // Many-to-many relationships
        [JsonIgnore] 
        [IgnoreDataMember] 
        public virtual ICollection<PersonPathologies> Pathologies { get; set; }

        [JsonIgnore] 
        [IgnoreDataMember] 
        public virtual ICollection<PersonsContactedByPatient> ContactedPatients { get; set;}
   
    }
}
