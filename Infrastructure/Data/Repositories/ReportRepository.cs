using AutoMapper;
using Domain.Entities.Reports;
using Domain.Interfaces;
using Domain.Interfaces.Reports;
using Domain.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class ReportRepository : BaseRepository<Report>, IReportRepository
    {
        private readonly IMapper _mapper;
        public ReportRepository(string connectionString, IMapper mapper)
              : base(connectionString)
        {
            _mapper = mapper;
        }

        public async Task<ReportModel> DeleteAsync(Guid id)
        {
            var sqlQuery = $"DELETE FROM \"Report\" WHERE \"Id\" = '{id}'  returning *";
            var result = await GetEnemyAsync(sqlQuery);
            return _mapper.Map<ReportModel>(result);
        }

        public async Task<IEnumerable<ReportModel>> GetAllForPage(int pageSize, int currentPage)
        {
            var sqlQuery = $"SELECT * FROM \"Report\" LIMIT {pageSize} OFFSET {(currentPage - 1) * pageSize}";
            var result = await GetListAsync(sqlQuery);
            return _mapper.Map<IEnumerable<ReportModel>>(result);
        }

        public async Task<IEnumerable<ReportModel>> GetAll()
        {
            var sqlQuery = $"SELECT * FROM \"Report\"";
            var result = await GetListAsync(sqlQuery);
            return _mapper.Map<IEnumerable<ReportModel>>(result);
        }
        public async Task<int> Count()
        {
            var sqlQuery = $"SELECT COUNT(*) FROM \"Report\"";
            var result = await GetColumnAsync(sqlQuery);
            return Convert.ToInt32(result);
        }

        public async Task<ReportModel> Get(Guid id)
        {
            var sqlQuery = $"SELECT * FROM \"Report\" WHERE \"Id\" = '{id}'";
            var result = await GetEnemyAsync(sqlQuery);
            return _mapper.Map<ReportModel>(result);
        }

        public async Task<ReportModel> InsertAsync(ReportModel model)
        {
            var sqlQuery = $"INSERT INTO \"Report\" (\"Id\",  \"Date\", \"NumberOfHour\", \"Recycling\", \"ReasonForRecycling\", \"DescriptionWork\") VALUES ('{Guid.NewGuid()}','{model.Date.ToShortDateString()}','{model.NumberOfHour}','{model.Recycling}','{model.ReasonForRecycling}','{model.DescriptionWork}')  returning *";
            var result = await GetEnemyAsync(sqlQuery);
            return _mapper.Map<ReportModel>(result);
        }

        public async Task<ReportModel> UpdateAsync(ReportModel model)
        {
            var sqlQuery = $"UPDATE \"Report\" SET  \"Date\"='{model.Date.ToShortDateString()}',\"NumberOfHour\"='{model.NumberOfHour}',\"Recycling\"='{model.Recycling}',\"ReasonForRecycling\"='{model.ReasonForRecycling}',\"DescriptionWork\"='{model.DescriptionWork}' WHERE \"Id\" = '{model.Id}'  returning *";
            var result = await GetEnemyAsync(sqlQuery);
            return _mapper.Map<ReportModel>(result);
        }

    }
}
