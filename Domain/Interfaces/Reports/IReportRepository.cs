using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Reports;
using Domain.Models.Reports;

namespace Domain.Interfaces.Reports
{
    public interface IReportRepository
    {
        Task<IEnumerable<ReportModel>> GetAllForPage(int pageSize, int currentPage);
        Task<ReportModel> InsertAsync(ReportModel model);
        Task<ReportModel> UpdateAsync(ReportModel model);
        Task<ReportModel> DeleteAsync(Guid id);
        Task<IEnumerable<ReportModel>> GetAll();
        Task<ReportModel> Get(Guid id);
        Task<int> Count();
    }
}
