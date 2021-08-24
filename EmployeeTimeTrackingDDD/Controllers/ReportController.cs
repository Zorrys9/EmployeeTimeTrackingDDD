using Api.DTOs.Employee;
using Api.DTOs.Report;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Reports;
using Domain.Models.EmployeeReport;
using Domain.Models.Filters;
using Domain.Models.Page;
using Domain.Models.Reports;
using Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("Reports")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly ITrackingLogic _trackingLogic;
        private readonly IMapper _mapper;

        public ReportController(IReportService reportService, ITrackingLogic trackingLogic, IMapper mapper)
        {
            _reportService = reportService;
            _trackingLogic = trackingLogic;
            _mapper = mapper;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Insert([FromForm] ReportDto model)
        {
            if (model == null)
            {
                return StatusCode(500);
            }
            var newModel = _mapper.Map<ReportModel>(model);
            var result = await _trackingLogic.InsertReportAsync(newModel);

            if (!result)
            {
                return StatusCode(500);
            }
            return Ok();
        }

        [HttpPut]
        [ValidateModel]
        public async Task<IActionResult> Update([FromForm] ReportDto model)
        {
            if (model == null)
            {
                return StatusCode(500);
            }
            var changedModel = _mapper.Map<ReportModel>(model);
            var result = await _reportService.UpdateAsync(changedModel);

            if (result == null)
            {
                return StatusCode(500);
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([Required] Guid id)
        {
            var result = await _trackingLogic.DeleteReportAsync(id);

            if (!result)
            {
                return StatusCode(500);
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 4)
        {
            PageInfoModel pageInfo = new PageInfoModel(pageNumber, 0, pageSize);

            var result = await _trackingLogic.GetReportsForPage(pageInfo);
            result.PageInfo = pageInfo;

            if (!result.List.Any() || result.PageInfo.CountItems == 0)
            {
                return StatusCode(500);
            }

            return Content(JsonConvert.SerializeObject(result), "application/json");
        }

        [HttpPost("Search")]
        [ValidateModel]
        public async Task<IActionResult> SearchReports([FromForm] SearchReportDto model, int pageNumber = 1, int pageSize = 4)
        {
            if (model == null)
            {
                return await GetAll(pageNumber, pageSize);
            }
            PageInfoModel pageInfo = new PageInfoModel(pageNumber, 0, pageSize);
            var result = await _trackingLogic.SearchReports(_mapper.Map<SearchModel>(model), pageInfo);
            if (!result.List.Any() || result.PageInfo.CountItems == 0)
            {
                return StatusCode(500);
            }

            return Content(JsonConvert.SerializeObject(result), "application/json");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportsById([FromRoute] Guid id, int pageNumber = 1, int pageSize = 4)
        {
            PageInfoModel pageInfo = new PageInfoModel(pageNumber, 0, pageSize);

            var result = await _trackingLogic.GetReportsEmployeeForPage(id, pageInfo);

            if (!result.List.Any() || result.PageInfo.CountItems == 0)
            {
                return StatusCode(500);
            }

            return Content(JsonConvert.SerializeObject(result), "application/json");
        }
    }
}
