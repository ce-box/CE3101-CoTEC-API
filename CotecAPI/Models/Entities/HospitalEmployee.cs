namespace CotecAPI.Models.Entities
{
    public class HospitalEmployee
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }


        // FK, references Hospital.Id
        public int Hospital_Id { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
}