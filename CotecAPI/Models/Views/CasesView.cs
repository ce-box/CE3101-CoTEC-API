namespace CotecAPI.Models.Views
{
    public class CasesView
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string FlagUrl { get; set; }
        public int Infected { get; set; }
        public int Recovered { get; set; }
        public int Deaths { get; set; }
        public int Active { get; set; }
        public int DailyIncrease { get; set; }
    }
}