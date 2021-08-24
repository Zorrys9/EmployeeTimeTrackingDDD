using Domain.Interfaces;
using Domain.Interfaces.EmployeeReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.EmployeeReport;
using Domain.Entities.EmployeeReports;
using AutoMapper;

namespace Infrastructure.Services
{
    public class EmployeeReportService :IEmployeeReportService
    {
        private readonly IEmployeeReportRepository _employeeReportRepository;
        private readonly IMapper _mapper;

        public EmployeeReportService(IEmployeeReportRepository employeeReportRepository, IMapper mapper)
        {
            _employeeReportRepository = employeeReportRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeReportModel> DeleteAsync(Guid reportId)
        {
            var result = await _employeeReportRepository.DeleteAsync(reportId);
            return result;
        }

        public async Task<IEnumerable<EmployeeReportModel>> GetByEmployee(Guid employeeId)
        {
            var result = await _employeeReportRepository.GetByEmployee(employeeId);
            return result;
        }
        public async Task<IEnumerable<EmployeeReportModel>> GetByEmployeeForPage(Guid employeeId, int pageSize, int currentPage)
        {
            var result = await _employeeReportRepository.GetByEmployeeForPage(employeeId, pageSize, currentPage);
            return result;
        }
        public async Task<int> CountByEmployee(Guid employeeId)
        {
            return await _employeeReportRepository.CountByEmployee(employeeId);
        }

        public async Task<Guid> GetByReport(Guid reportId)
        {
            return await _employeeReportRepository.GetByReport(reportId);
        }

        public async Task<EmployeeReportModel> InsertAsync(EmployeeReportModel model)
        {
            var result = await _employeeReportRepository.InsertAsync(model);
            return result;
        }
    }
}
