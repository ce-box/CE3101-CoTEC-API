using System.Collections.Generic;

namespace CotecAPI.Models.Entities
{
    public class PharmaceuticalCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // One-to-Many relationship
        public virtual ICollection<Medication> Madications { get; set; }
    }
}