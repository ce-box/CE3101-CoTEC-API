using System.Collections.Generic;

namespace CotecAPI.Models
{
    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string FlagUrl { get; set; }


        // FK references Continent.Code
        public string ContinentCode { get; set; }        
        public virtual Continent Continent { get;set; }


        // One-to-many relationships
        public virtual ICollection<Region> Regions { get;set; }
        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Event> CountryEvents { get; set; }


        // Many-to-many relationships
        public virtual ICollection<CountrySanitaryMeasures> ImplementedSanitaryMeasures { get; set; }
        public virtual ICollection<CountryContainmemtMeasures> ImplementedContainmemtMeasures { get; set; }
    }
}