using Domain.Entities.Reports;
using Domain.Interfaces.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class SummaryReportRepository :BaseRepository<SummaryReport>, ISummaryReportRepository
    {
    }
}
