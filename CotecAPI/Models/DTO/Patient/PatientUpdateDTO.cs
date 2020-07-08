using System;

namespace CotecAPI.Models.DTO.Patient
{
    public class PatientUpdateDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool Hospitalized { get; set; }
        public DateTime DoB { get; set; }
        public bool ICU { get; set; }
        public int Status { get; set; }
        public int Hospital_Id { get; set; }
    }
}