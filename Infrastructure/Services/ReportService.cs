using AutoMapper;
using Domain.Interfaces.Reports;
using Domain.Models.EmployeeReport;
using Domain.Models.Filters;
using Domain.Models.Reports;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ReportService :IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly ISummaryReportRepository _summaryReportRepository;
        private readonly IDetailReportRepository _searchReportsRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public ReportService(IReportRepository reportRepository, ISummaryReportRepository summaryReportRepository,
            IDetailReportRepository searchReportsRepository, ILogger logger, IMapper mapper)
        {
            _summaryReportRepository = summaryReportRepository;
            _searchReportsRepository = searchReportsRepository;
            _reportRepository = reportRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ReportModel> DeleteAsync(Guid id)
        {
            var result = await _reportRepository.DeleteAsync(id);
            return result;
        }

        public async Task<IEnumerable<ReportModel>> GetAllForPage(int pageSize, int currentPage)
        {
            var result = await _reportRepository.GetAllForPage(pageSize, currentPage);
            return result;
        }

        public async Task<IEnumerable<ReportModel>> GetAll()
        {
            var result = await _reportRepository.GetAll();
            return _mapper.Map<IEnumerable<ReportModel>>(result);
        }

        public async Task<ReportModel> Get(Guid id)
        {
            var result = await _reportRepository.Get(id);
            return result;
        }

        public async Task<ReportModel> InsertAsync(ReportModel model)
        {
            var result = await _reportRepository.InsertAsync(model);
            if (result != null)
            {
                _logger.Information("A new report has been created");
            }
            return result;
        }

        public async Task<ReportModel> UpdateAsync(ReportModel model)
        {
            var result = await _reportRepository.UpdateAsync(model);
            return result;
        }

        public async Task<SummaryReportModel> SummaryReport(Guid id)
        {
            var result = await _summaryReportRepository.Get(id);
            return result;
        }

        public async Task<IEnumerable<SummaryReportModel>> SummaryReports()
        {
            var result = await _summaryReportRepository.GetAll();
            return result;
        }

        public async Task<ICollection<EmployeeReportModel>> SearchReports(SearchModel model, int pageSize, int currentPage)
        {
            if (model.LastDate == DateTime.MinValue)
            {
                model.LastDate = DateTime.Now;
            }
            var result = await _searchReportsRepository.Search(model, pageSize, currentPage);
            return _mapper.Map<ICollection<EmployeeReportModel>>(result);
        }

        public async Task<int> CountAll()
        {
            return await _reportRepository.Count();
        }

        public async Task<int> CountFound(SearchModel model)
        {
            if (model.LastDate == DateTime.MinValue)
            {
                model.LastDate = DateTime.Now;
            }
            return await _searchReportsRepository.Count(model);
        }
    }
}
