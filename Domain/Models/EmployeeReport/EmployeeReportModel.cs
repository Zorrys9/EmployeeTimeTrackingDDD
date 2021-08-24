using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Domain.Models.EmployeeReport
{
    public class EmployeeReportModel
    {       
        [JsonProperty("ФИО сотрудника")]
        [XmlElement("ФИО_сотрудника")]
        public string FullNameEmployee { get; set; }
        [JsonProperty("Должность сотрудника")]
        [XmlElement("Должность_сотрудника")]
        public string PositionEmployee { get; set; }
        [JsonProperty("Количество отработанных часов")]
        [XmlElement("Количество_отработанных_часов")]
        public int NumberOfHour { get; set; }
        [JsonProperty("Наличие переработки")]
        [XmlElement("Наличие_переработки")]
        public bool Recycling { get; set; }
        [JsonProperty("Дата создания отчета")]
        [XmlElement("Дата_создания_отчета")]
        public DateTime Date { get; set; }
        [JsonProperty("Полное описание выполненной работы")]
        [XmlElement("Полное_описание_выполненной_работы")]
        public string DescriptionWork { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public Guid EmployeeId { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public Guid ReportId { get; set; }
    }
}
