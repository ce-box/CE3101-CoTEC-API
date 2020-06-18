namespace CotecAPI.Models
{
    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; }


        // FK
        public int PharmaceuticCo { get; set; }
    }
}
