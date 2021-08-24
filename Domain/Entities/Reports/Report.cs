using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.EmployeeReports;
namespace Domain.Entities.Reports
{
    public class Report
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int NumberOfHour { get; set; }
        public int Recycling { get; set; }
        [MaxLength(50)]
        public string ReasonForRecycling { get; set; }
        [MaxLength(100)]
        [Required]
        public string DescriptionWork { get; set; }


        public IEnumerable<EmployeeReport> EmployeeReports { get; set; }
    }
}
