using Domain.Entities.Employees;
using Domain.Entities.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.EmployeeReports
{
    public class EmployeeReport
    {
        [Key]
        [Required]
        public Guid ReportId { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }

        public Report Report { get; set; }

        public Employee Employee { get; set; }
    }
}
