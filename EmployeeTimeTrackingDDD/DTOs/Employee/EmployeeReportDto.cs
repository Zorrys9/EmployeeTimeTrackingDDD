using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Api.DTOs.Employee
{
    public class EmployeeReportDto
    {   
        public string FullNameEmployee { get; set; }
        public string PositionEmployee { get; set; }
        public int NumberOfHour { get; set; }
        public bool Recycling { get; set; }
        public DateTime Date { get; set; }
        public string DescriptionWork { get; set; }
    }
}
