namespace CotecAPI.Models
{
    public class PatientPathologies
    {
        // FKs of Many-to-Many relationships
        public string PatientDni { get; set; }
        public virtual Patient Patient { get; set; }
        
        public string PathologyName { get; set; }
        public virtual Pathology Pathology { get; set; }
    }
}
