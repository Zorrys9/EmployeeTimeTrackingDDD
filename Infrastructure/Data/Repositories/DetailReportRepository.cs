using AutoMapper;
using Domain.Entities.Reports;
using Domain.Interfaces.Reports;
using Domain.Models.Filters;
using Domain.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class DetailReportRepository : BaseRepository<DetailReport> , IDetailReportRepository
    {
        private readonly IMapper _mapper;
        public DetailReportRepository(string connectionString, IMapper mapper)
         : base(connectionString)
        {
            _mapper = mapper;
        }

        public async Task<ICollection<DetailReportModel>> Search(SearchModel model, int pageSize, int currentPage)
        {
            var sqlQuery = $"SELECT (emp.\"FirstName\" || ' ' || emp.\"SecondName\" || ' ' || emp.\"LastName\") AS \"FullNameEmployee\", emp.\"Position\" AS \"PositionEmployee\", rep.\"Date\", rep.\"NumberOfHour\", rep.\"Recycling\", rep.\"DescriptionWork\" FROM \"EmployeeReports\" AS empRep JOIN \"Employee\" AS \"emp\" ON emp.\"Id\" = empRep.\"EmployeeId\" JOIN \"Report\" AS \"rep\" ON rep.\"Id\" = empRep.\"ReportId\"";
            var whereComponent = $" WHERE (emp.\"FirstName\" LIKE '%{model.FirstName}%') AND (emp.\"SecondName\" LIKE '%{model.SecondName}%') AND (emp.\"LastName\" LIKE '%{model.LastName}%') AND (emp.\"Position\" LIKE '%{model.Position}%') AND (rep.\"Date\" >= '{model.FirstDate}') AND (rep.\"Date\" <= '{model.LastDate}')";
            var pagination = $" LIMIT {pageSize} OFFSET {(currentPage - 1) * pageSize}";

            sqlQuery += whereComponent + pagination;
            var result = await GetListAsync(sqlQuery);
            return _mapper.Map<IEnumerable<DetailReportModel>>(result).ToList();
        }

        public async Task<int> Count(SearchModel model)
        {
            var sqlQuery = $"SELECT COUNT(*) FROM \"EmployeeReports\" AS empRep JOIN \"Employee\" AS \"emp\" ON emp.\"Id\" = empRep.\"EmployeeId\" JOIN \"Report\" AS \"rep\" ON rep.\"Id\" = empRep.\"ReportId\"";
            var whereComponent = $" WHERE (emp.\"FirstName\" LIKE '%{model.FirstName}%') AND (emp.\"SecondName\" LIKE '%{model.SecondName}%') AND (emp.\"LastName\" LIKE '%{model.LastName}%') AND (emp.\"Position\" LIKE '%{model.Position}%') AND (rep.\"Date\" >= '{model.FirstDate}') AND (rep.\"Date\" <= '{model.LastDate}')";

            sqlQuery += whereComponent;
            var result = await GetColumnAsync(sqlQuery);
            return Convert.ToInt32(result);
        }
    }
}
