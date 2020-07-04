using System.Collections.Generic;

namespace CotecAPI.Models.Entities
{
    public class ContainmentMeasure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Many-to-many relationship
        public virtual ICollection<CountryContainmentMeasures> ImplementedMeasures { get; set; }
    }
}
