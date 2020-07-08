using System;

namespace CotecAPI.Models.Views
{
    public class ReportView
    {
        public DateTime Date { get; set; }
        public int Infected { get; set; }
        public int Deaths { get; set; }
    }
}