using System;
using System.Text.Json.Serialization;

namespace CotecAPI.Models.Views
{
    public class MeasureView
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Status { get; set; } //Active or Inactive
    }
}