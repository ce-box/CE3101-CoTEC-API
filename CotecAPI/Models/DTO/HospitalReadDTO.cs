namespace CotecAPI.Models.DTO
{
    public class HospitalReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public string Phone { get; set; }
        public int Capacity { get; set; }
        public int ICU_Capacity { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }
}