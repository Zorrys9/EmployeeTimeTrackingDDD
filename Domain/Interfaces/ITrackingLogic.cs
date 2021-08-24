using Domain.Models.EmployeeReport;
using Domain.Models.Filters;
using Domain.Models.Page;
using Domain.Models.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITrackingLogic
    {
        Task<bool> InsertReportAsync(ReportModel model);
        Task<bool> DeleteReportAsync(Guid reportId);
        Task<PaginationModel<EmployeeReportModel>> GetReportsEmployeeForPage(Guid employeeId, PageInfoModel pageInfo);
        Task<ICollection<EmployeeReportModel>> GetReportsEmployee(Guid employeeId);
        Task<PaginationModel<EmployeeReportModel>> GetReportsForPage(PageInfoModel pageInfo);
        Task<FileContentResult> DetailReportsJson();
        Task<FileContentResult> DetailReportsXml();
        Task<FileContentResult> DetailReportsEmployeeJson(Guid employeeId);
        Task<FileContentResult> DetailReportsEmployeeXml(Guid employeeId);
        Task<FileContentResult> SummaryReportsJson();
        Task<FileContentResult> SummaryReportsXml();
        Task<FileContentResult> SummaryReportsEmployeeJson(Guid employeeId);
        Task<FileContentResult> SummaryReportsEmployeeXml(Guid employeeId);
        Task<bool> SetReports(IFormFile file);
        Task<PaginationModel<EmployeeReportModel>> SearchReports(SearchModel model, PageInfoModel pageInfo);
    }
}
