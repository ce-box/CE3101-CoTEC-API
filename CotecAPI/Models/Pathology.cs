using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CotecAPI.Models
{
    public class Pathology
    {  
        [Key]
        [DataType("varchar")]
        [MaxLength(50)]
        public string Name { get; set; }

        [DataType("varchar")]
        [MaxLength(255)]
        [Required]
        public string Symptoms { get; set; }

        [DataType("varchar")]
        [MaxLength(255)]
        [Required]
        public string Description { get; set; }

        [DataType("varchar")]
        [MaxLength(255)]
        [Required]
        public string Treatment { get; set; }


        // Many-to-many relationships
        public virtual ICollection<PersonPathologies> PersonPathologies { get; set; }
        public virtual ICollection<PatientPathologies> PatientPathologies { get; set; }

    }
}
