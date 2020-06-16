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


        // One-to-many relationship
        public virtual ICollection<Region> Regions { get;set; }
    }
}