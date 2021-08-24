using Domain.Entities.EmployeeReports;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Employees
{
    public class Employee
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [Required]
        public string SecondName { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [MaxLength(30)]
        [Required]
        public string Position { get; set; }

        public IEnumerable<EmployeeReport> EmployeeReports { get; set; }
    }
}
