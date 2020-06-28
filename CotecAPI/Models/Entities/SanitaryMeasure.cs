using System.Collections.Generic;

namespace CotecAPI.Models.Entities
{
    public class SanitaryMeasure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        // Many-to-many relationships
        public virtual ICollection<CountrySanitaryMeasures> ImplementedMeasures { get; set; }

    }
}