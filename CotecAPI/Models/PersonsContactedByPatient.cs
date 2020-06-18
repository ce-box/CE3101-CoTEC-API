namespace CotecAPI.Models
{
    public class PersonsContactedByPatient
    {
        public string MeetingDate { get; set; }


        //FK
        public string PatientDni { get; set; }
        public virtual Patient Patient { get; set; }
        public string ContactDni { get; set; }
        public virtual ContactedPerson Contacted { get; set; }
    }
}
