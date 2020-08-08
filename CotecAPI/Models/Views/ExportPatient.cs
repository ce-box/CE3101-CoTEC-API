using System;

namespace CotecAPI.Models.Views
{
    public class ExportPatient
    {
        public string dni { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public DateTime dob { get; set; }
        public string province { get; set; }
        public string canton { get; set; }
        public string district { get; set; }
        public string sex { get; set; }

    }
}