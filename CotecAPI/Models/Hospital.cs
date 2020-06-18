using System.Collections.Generic;

namespace CotecAPI.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public string Phone { get; set; }
        public int Capacity { get; set; }
        public int ICU_Capacity { get; set; }


        // FK, References Region.Name and Region.CountryCode
        public string Region { get; set; }
        public string Country { get; set; }
        public virtual Region HRegion { get; set; }

        // One-to-many relationships
        public virtual ICollection<HospitalEmployee> Employees { get; set; }
    }
}