using AutoMapper;
using Domain.Entities.EmployeeReports;
using Domain.Entities.Reports;
using Domain.Interfaces;
using Domain.Interfaces.EmployeeModels;
using Domain.Interfaces.EmployeeReports;
using Domain.Interfaces.Reports;
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

namespace Infrastructure.Logics
{
    public class TrackingLogic : ITrackingLogic
    {
        private readonly IEmployeeReportService _employeeReportService;
        private readonly IEmployeeService _employeeService;
        private readonly IReportService _reportService;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public TrackingLogic(IReportService reportService, IEmployeeReportService employeeReportService,
            IMapper mapper, IEmployeeService employeeService, IFileService fileService)
        {
            _employeeReportService = employeeReportService;
            _employeeService = employeeService;
            _reportService = reportService;
            _fileService = fileService;
            _mapper = mapper;
        }
        public async Task<bool> DeleteReportAsync(Guid reportId)
        {
            var resultDelete = await _employeeReportService.DeleteAsync(reportId);
            var result = await _reportService.DeleteAsync(resultDelete.ReportId);
            return result != null;
        }

        public async Task<bool> InsertReportAsync(ReportModel model)
        {
            var report = await _reportService.InsertAsync(model);
            var employeeReportModel = _mapper.Map<EmployeeReportModel>(model);
            employeeReportModel.ReportId = report.Id;
            var result = await _employeeReportService.InsertAsync(employeeReportModel);
            return result != null;
        }

        public async Task<PaginationModel<EmployeeReportModel>> GetReportsForPage(PageInfoModel pageInfo)
        {
            pageInfo.CountItems = await _reportService.CountAll();
            pageInfo.CalculateTotalPage();

            var reportsList = await _reportService.GetAllForPage(pageInfo.PageSize, pageInfo.CurrentPage);
            PaginationModel<EmployeeReportModel> result = new PaginationModel<EmployeeReportModel>();

            foreach (var report in reportsList)
            {
                var employeeId = await _employeeReportService.GetByReport(report.Id);
                EmployeeReportModel Model = _mapper.Map<EmployeeReportModel>(report);
                var employee = await _employeeService.Get(employeeId);
                Model.FullNameEmployee = _mapper.Map<EmployeeReportModel>(employee).FullNameEmployee;
                Model.PositionEmployee = employee.Position;

                result.List.Add(Model);
            }
            return result;
        }

        public async Task<ICollection<EmployeeReportModel>> GetAllReports()
        {
            var reportsList = await _reportService.GetAll();
            ICollection<EmployeeReportModel> result = new List<EmployeeReportModel>();

            foreach (var report in reportsList)
            {
                var employeeId = await _employeeReportService.GetByReport(report.Id);
                EmployeeReportModel Model = _mapper.Map<EmployeeReportModel>(report);
                var employee = await _employeeService.Get(employeeId);
                Model.FullNameEmployee = _mapper.Map<EmployeeReportModel>(employee).FullNameEmployee;
                Model.PositionEmployee = employee.Position;

                result.Add(Model);
            }
            return result;
        }

        public async Task<PaginationModel<EmployeeReportModel>> SearchReports(SearchModel model, PageInfoModel pageInfo)
        {
            pageInfo.CountItems = await _reportService.CountFound(model);
            pageInfo.CalculateTotalPage();
            var reports = await _reportService.SearchReports(model, pageInfo.PageSize, pageInfo.CurrentPage);

            PaginationModel<EmployeeReportModel> result = new();

            result.PageInfo = pageInfo;
            result.List = reports;
            return result;
        }

        public async Task<PaginationModel<EmployeeReportModel>> GetReportsEmployeeForPage(Guid employeeId, PageInfoModel pageInfo)
        {
            pageInfo.CountItems = await _employeeReportService.CountByEmployee(employeeId);
            pageInfo.CalculateTotalPage();

            var employeeReportsList = await _employeeReportService.GetByEmployeeForPage(employeeId, pageInfo.PageSize, pageInfo.CurrentPage);
            PaginationModel<EmployeeReportModel> pagination = new();
            pagination.PageInfo = pageInfo;
            pagination.List = new List<EmployeeReportModel>();

            foreach (var item in employeeReportsList)
            {
                var employee = await _employeeService.Get(item.EmployeeId);
                var report = await _reportService.Get(item.ReportId);
                EmployeeReportModel Model = _mapper.Map<EmployeeReportModel>(report);
                Model.FullNameEmployee = _mapper.Map<EmployeeReportModel>(employee).FullNameEmployee;
                Model.PositionEmployee = employee.Position;
                pagination.List.Add(Model);
            }
            return pagination;
        }

        public async Task<ICollection<EmployeeReportModel>> GetReportsEmployee(Guid employeeId)
        {
            var employeeReportsList = await _employeeReportService.GetByEmployee(employeeId);
            ICollection<EmployeeReportModel> result = new List<EmployeeReportModel>();

            foreach (var item in employeeReportsList)
            {
                var employee = await _employeeService.Get(item.EmployeeId);
                var report = await _reportService.Get(item.ReportId);
                EmployeeReportModel Model = _mapper.Map<EmployeeReportModel>(report);
                Model.FullNameEmployee = _mapper.Map<EmployeeReportModel>(employee).FullNameEmployee;
                Model.PositionEmployee = employee.Position;
                result.Add(Model);
            }
            return result;
        }

        public async Task<FileContentResult> DetailReportsJson()
        {
            var reports = await GetAllReports();
            return _fileService.GetJson(reports);
        }

        public async Task<FileContentResult> DetailReportsXml()
        {
            var reports = await GetAllReports();
            return _fileService.GetXml(reports);
        }

        public async Task<FileContentResult> DetailReportsEmployeeJson(Guid employeeId)
        {
            var reports = await GetReportsEmployee(employeeId);
            return _fileService.GetJson(reports);
        }

        public async Task<FileContentResult> DetailReportsEmployeeXml(Guid employeeId)
        {
            var reports = await GetReportsEmployee(employeeId);
            return _fileService.GetXml(reports);
        }
        public async Task<FileContentResult> SummaryReportsEmployeeJson(Guid employeeId)
        {
            var report = await _reportService.SummaryReport(employeeId);
            var employee = await _employeeService.Get(employeeId);
            report.FullName = $"{employee.FirstName} {employee.SecondName} {employee.LastName}";
            report.Position = employee.Position;
            return _fileService.GetJson(report);
        }

        public async Task<FileContentResult> SummaryReportsEmployeeXml(Guid employeeId)
        {
            var report = await _reportService.SummaryReport(employeeId);
            var employee = await _employeeService.Get(employeeId);
            report.FullName = $"{employee.FirstName} {employee.SecondName} {employee.LastName}";
            report.Position = employee.Position;
            return _fileService.GetXml(report);
        }
        public async Task<FileContentResult> SummaryReportsJson()
        {
            var reports = await _reportService.SummaryReports();
            foreach (var report in reports)
            {
                var employee = await _employeeService.Get(report.EmployeeId);
                report.FullName = $"{employee.FirstName} {employee.SecondName} {employee.LastName}";
                report.Position = employee.Position;
            }
            return _fileService.GetJson(reports);
        }

        public async Task<FileContentResult> SummaryReportsXml()
        {
            var reports = await _reportService.SummaryReports();
            foreach (var report in reports)
            {
                var employee = await _employeeService.Get(report.EmployeeId);
                report.FullName = $"{employee.FirstName} {employee.SecondName} {employee.LastName}";
                report.Position = employee.Position;
            }
            return _fileService.GetXml(reports);
        }

        public async Task<bool> SetReports(IFormFile file)
        {
            var reports = _fileService.GetReportsFromFile(file);

            if (reports == null || file == null)
            {
                return false;
            }

            foreach (var report in reports)
            {
                var newReport = _mapper.Map<ReportModel>(report);
                var reportModel = await _reportService.InsertAsync(newReport);
                EmployeeReportModel employeeReport = new EmployeeReportModel()
                {
                    EmployeeId = report.EmployeeId,
                    ReportId = reportModel.Id
                };
                await _employeeReportService.InsertAsync(employeeReport);
            }
            return true;
        }
    }
}
