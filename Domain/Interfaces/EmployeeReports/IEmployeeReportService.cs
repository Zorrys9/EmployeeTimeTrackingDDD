using Domain.Entities.EmployeeReports;
using Domain.Models.EmployeeReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.EmployeeReports
{
    public interface IEmployeeReportService
    {
        Task<EmployeeReportModel> InsertAsync(EmployeeReportModel model);
        Task<EmployeeReportModel> DeleteAsync(Guid reportId);
        Task<IEnumerable<EmployeeReportModel>> GetByEmployee(Guid employeeId);
        Task<IEnumerable<EmployeeReportModel>> GetByEmployeeForPage(Guid employeeId, int pageSize, int currentPage);
        Task<int> CountByEmployee(Guid employeeId);
        Task<Guid> GetByReport(Guid reportId);
    }
}
