using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Domain.Models.Reports
{
    public class SummaryReportModel
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public int NumberOfHour { get; set; }
        public int Recycling { get; set; }
        public int NumberOfReports { get; set; }
        [XmlIgnore]
        [JsonIgnore]
        public Guid EmployeeId { get; set; }
    }
}
