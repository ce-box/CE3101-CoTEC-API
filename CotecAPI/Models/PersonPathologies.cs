using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotecAPI.Models
{
    public class PersonPathologies
    {
        public string Prescription { get; set; }


        //FK
        public string PersonDni { get; set; }
        public virtual ContactedPerson Contacted { get; set; }
        public string PathologyName { get; set; }
        public virtual Pathology Pathology { get; set; }
    }
}
