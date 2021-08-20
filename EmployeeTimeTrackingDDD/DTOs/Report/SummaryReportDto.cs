using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Api.DTOs.Report
{
    public class SummaryReportDto
    {    
        [JsonProperty("ФИО сотрудника")]
        [XmlElement("ФИО сотрудника")]
        public string FullName { get; set; }
        [JsonProperty("Должность сотрудника")]
        [XmlElement("Должность сотрудника")]
        public string Position { get; set; }
        [JsonProperty("Общее количество отработанных часов")]
        [XmlElement("Общее количество отработанных часов")]
        public int NumberOfHour { get; set; }
        [JsonProperty("Общее количество часов переработки")]
        [XmlElement("Общее количество часов переработки")]
        public int Recycling { get; set; }
        [JsonProperty("Количество написанных отчетов")]
        [XmlElement("Количество написанных отчетов")]
        public int NumberOfReports { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public Guid EmployeeId { get; set; }
    }
}
