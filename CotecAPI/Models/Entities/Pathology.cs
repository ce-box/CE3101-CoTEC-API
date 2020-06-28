using System.Collections.Generic;

namespace CotecAPI.Models.Entities
{
    public class Pathology
    {  
        public string Name { get; set; }
        public string Symptoms { get; set; }
        public string Description { get; set; }
        public string Treatment { get; set; }


        // Many-to-many relationships
        public virtual ICollection<PersonPathologies> PersonPathologies { get; set; }
        public virtual ICollection<PatientPathologies> PatientPathologies { get; set; }

    }
}
