using System.Collections.Generic;

namespace CotecAPI.Models
{
    public class Continent
    {
        public string Code { get; set; }
        public string Name { get; set; }


        // One-to-many relationship
        public virtual ICollection<Country> Countries { get; set;}
    }
}