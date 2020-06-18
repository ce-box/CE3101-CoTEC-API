namespace CotecAPI.Models
{
    public class PersonPathologies
    {

        // FKs of Many-to-Many relationships
        public string PersonDni { get; set; }
        public virtual ContactedPerson Contacted { get; set; }
        
        public string PathologyName { get; set; }
        public virtual Pathology Pathology { get; set; }
    }
}
