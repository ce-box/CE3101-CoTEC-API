﻿using System;
using System.Collections.Generic;

namespace CotecAPI.Models.Entities
{
    public class Patient
    {
        public string Dni { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public bool Hospitalized { get; set; }
        public bool ICU { get; set; }


        // FKs, One-to-many relationship
        public int Status { get; set; }
        public virtual PatientStatus PatientStatus { get; set; }

        public int Hospital_Id { get; set; }
        public virtual Hospital Hospital { get; set; }

        public string Region { get; set; }
        public string Country { get; set; }
        public virtual Region PatientRegion { get; set; }


        // Many-to-many relationships
        public virtual ICollection<PatientPathologies> Pathologies { get; set; }
        public virtual ICollection<PatientMedications> Medications { get; set; }
        public virtual ICollection<PersonsContactedByPatient> ContactedPersons { get; set; }
    }
}
