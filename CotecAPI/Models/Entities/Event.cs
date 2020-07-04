using System;

namespace CotecAPI.Models.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }

        // FK references Country.Code
        public string CountryCode { get; set; }
        public virtual Country Country { get; set; }
    }
}