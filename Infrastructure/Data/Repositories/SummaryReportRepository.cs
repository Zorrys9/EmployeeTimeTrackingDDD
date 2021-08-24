using AutoMapper;
using Domain.Entities.Reports;
using Domain.Interfaces.Reports;
using Domain.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class SummaryReportRepository :BaseRepository<SummaryReport>, ISummaryReportRepository
    {
        private readonly IMapper _mapper;
        public SummaryReportRepository(string connectionString, IMapper mapper)
       : base(connectionString)
        {
            _mapper = mapper;
        }

        public async Task<SummaryReportModel> Get(Guid id)
        {
            var sqlQuery = $"SELECT COUNT(\"Id\") AS \"NumberOfReports\", SUM(\"NumberOfHour\") AS \"NumberOfHOur\", SUM(\"Recycling\") AS \"Recycling\" FROM \"Report\" as \"rep\" JOIN \"EmployeeReports\" as \"emp\" ON rep.\"Id\" = emp.\"ReportId\"  WHERE emp.\"EmployeeId\" = '{id}'";
            var result = await GetEnemyAsync(sqlQuery);
            return _mapper.Map<SummaryReportModel>(result);
        }

        public async Task<IEnumerable<SummaryReportModel>> GetAll()
        {
            var sqlQuery = $"SELECT emp.\"EmployeeId\", COUNT(\"Id\") AS \"NumberOfReports\", SUM(\"NumberOfHour\") AS \"NumberOfHOur\", SUM(\"Recycling\") AS \"Recycling\" FROM \"Report\" as \"rep\" JOIN \"EmployeeReports\" as \"emp\" ON rep.\"Id\" = emp.\"ReportId\" GROUP BY emp.\"EmployeeId\"";
            var result = await GetListAsync(sqlQuery);
            return _mapper.Map<IEnumerable<SummaryReportModel>>(result);
        }
    }
}

