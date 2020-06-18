namespace CotecAPI.Models
{
    public class PatientPathologies
    {
        // FKs of Many-to-Many relationships
        public string PatientDni { get; set; }
        public virtual Patient Patient { get; set; }
        
        public string PatholohyName { get; set; }
        public virtual Pathology Pathology { get; set; }
    }
}
