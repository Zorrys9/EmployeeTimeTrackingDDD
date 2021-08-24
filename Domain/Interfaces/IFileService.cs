using Domain.Models.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFileService
    {
        Task SaveImageAsync(IFormFile file, Guid employeeId);
        void DeleteImageAsync(Guid employeeId);
        FileContentResult GetJson<T>(T item);
        FileContentResult GetXml<T>(T item);
        FileContentResult GetTemplateReport(Guid id);
        IEnumerable<ReportModel> GetReportsFromFile(IFormFile file);
    }
}
