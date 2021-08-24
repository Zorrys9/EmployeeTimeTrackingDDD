using Domain.Entities.Reports;
using Domain.Models.Filters;
using Domain.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Reports
{
    public interface IDetailReportRepository
    {
        Task<ICollection<DetailReportModel>> Search(SearchModel model, int pageSize, int currentPage);
        Task<int> Count(SearchModel model);
    }
}
