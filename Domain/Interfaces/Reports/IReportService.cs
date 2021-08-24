using Domain.Models.EmployeeReport;
using Domain.Models.Filters;
using Domain.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Reports
{
    public interface IReportService
    {
        Task<ReportModel> InsertAsync(ReportModel model);
        Task<ReportModel> UpdateAsync(ReportModel model);
        Task<ReportModel> DeleteAsync(Guid Id);
        Task<IEnumerable<ReportModel>> GetAllForPage(int pageSize, int currentPage);
        Task<IEnumerable<ReportModel>> GetAll();
        Task<ReportModel> Get(Guid id);
        Task<SummaryReportModel> SummaryReport(Guid id);
        Task<IEnumerable<SummaryReportModel>> SummaryReports();
        Task<ICollection<EmployeeReportModel>> SearchReports(SearchModel model, int pageSize, int currentPage);
        Task<int> CountAll();
        Task<int> CountFound(SearchModel model);
    }
}
