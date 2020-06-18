using System;

namespace CotecAPI.Models
{
    public class CountryContainmemtMeasures
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }


        // FK reference Country.Code and ContainmentMeasure.Id
        public string CountryCode { get; set; }
        public virtual Country Country { get; set; }

        public int MeasureId { get; set; }
        public virtual ContainmentMeasure Measure { get; set; }
    }
}
