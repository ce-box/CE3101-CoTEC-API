using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CotecAPI.Models
{
    public class PharmaceuticalCompany
    {
        [Key]
        public int Id { get; set; }

        [DataType("varchar")]
        [MaxLength(60)]
        public string Name { get; set; }

        // One-to-Many relationship
        public virtual ICollection<Medication> Madications { get; set; }
    }
}