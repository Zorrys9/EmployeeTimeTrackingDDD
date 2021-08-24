using Domain.Entities.Reports;
using Domain.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Reports
{
    public interface ISummaryReportRepository
    {
        Task<SummaryReportModel> Get(Guid id);
        Task<IEnumerable<SummaryReportModel>> GetAll();
    }
}
