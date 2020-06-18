namespace CotecAPI.Models
{
    public class PatientPathologies
    {
        public string Prescription { get; set; }


        //FK
        public string PatientDni { get; set; }
        public virtual Patient Patient { get; set; }
        public string PatholohyName { get; set; }
        public virtual Pathology Pathology { get; set; }
    }
}
