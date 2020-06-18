using System.Collections.Generic;

namespace CotecAPI.Models
{
    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; }


        // FK reference PharmaceuticalCompany.Id
        public int PharmaceuticCo { get; set; }
        public virtual PharmaceuticalCompany PCompany { get; set; }

        // Many-to-many relationship
        public virtual ICollection<PatientMedications> PatientMedications { get; set; }
    }
}
