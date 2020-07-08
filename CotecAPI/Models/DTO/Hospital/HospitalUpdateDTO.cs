namespace CotecAPI.Models.DTO
{
    public class HospitalUpdateDTO
    {
        public string ManagerName { get; set; }
        public string Phone { get; set; }
        public int Capacity { get; set; }
        public int ICU_Capacity { get; set; }
    }
}