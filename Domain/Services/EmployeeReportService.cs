using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class EmployeeReportService :IEmployeeReportService
    {
        private readonly IEmployeeReportRepository _employeeReportRepository;

        public EmployeeReportService(IEmployeeReportRepository employeeReportRepository)
        {
            _employeeReportRepository = employeeReportRepository;
        }
    }
}
