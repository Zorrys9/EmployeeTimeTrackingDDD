using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("Files")]
    public class FileController : Controller
    {
        private readonly ITrackingLogic _trackingLogic;
        private readonly IFileService _fileService;

        public FileController(ITrackingLogic trackingLogic, IFileService fileService)
        {
            _trackingLogic = trackingLogic;
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
