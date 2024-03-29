﻿namespace CotecAPI.Models.Entities
{
    public class PatientMedications
    {
        public string Prescription { get; set; }


        // FKs of Many-to-Many relationships 
        public string PatientDni { get; set; }
        public virtual Patient Patient { get; set; }

        public int MedicationId { get; set; }
        public virtual Medication Medication { get; set; }
    }
}
