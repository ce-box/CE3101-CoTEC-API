using System.Collections.Generic;

namespace CotecAPI.Models
{
    public class PatientStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // One-to-many relationship
        public virtual ICollection<Patient> Patients { get; set; }
        
    }
}
