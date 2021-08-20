using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("Reports")]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly ITrackingLogic _trackingLogic;

        public ReportController(IReportService reportService, ITrackingLogic trackingLogic)
        {
            _reportService = reportService;
            _trackingLogic = trackingLogic;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
