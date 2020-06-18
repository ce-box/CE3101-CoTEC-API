using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CotecAPI.Models
{
    public class PatientStatus
    {
        [Key]
        public int Id { get; set; }

        [DataType("varchar")]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Patient> Patients { get; set;}
    }
}
