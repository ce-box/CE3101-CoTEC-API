namespace CotecAPI.Models
{
    public class PatientMedications
    {
        public string Prescription { get; set; }


        //FK
        public string PatientDni { get; set; }
        public virtual Patient Patient { get; set; }
        public string Medicationid { get; set; }
        public virtual Medication Medication { get; set; }
    }
}
