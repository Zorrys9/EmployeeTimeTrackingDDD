using Api.DTOs.Employee;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models.Employees;
using Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("Employees")]
    public class EmployeeController : Controller
    {
        private readonly IAccountLogic _accountLogic;
        private readonly IMapper _mapper;
        public EmployeeController(IAccountLogic accountLogic, IMapper mapper)
        {
            _accountLogic = accountLogic;
            _mapper = mapper;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Insert([FromForm] EmployeeDto model)
        {
            if (model == null)
            {
                return StatusCode(500);
            }
            var newModel = _mapper.Map<EmployeeModel>(model);
            var result = await _accountLogic.CreateEmployee(newModel);

            if (!result)
            {
                return StatusCode(500);
            }

            return StatusCode(201);
        }

        [HttpPut]
        [ValidateModel]
        public async Task<IActionResult> Update([FromForm] EmployeeDto model)
        {
            if (model == null)
            {
                return StatusCode(500);
            }
            var changedModel = _mapper.Map<EmployeeModel>(model);
            var result = await _accountLogic.UpdateEmployee(changedModel);

            if (!result)
            {
                return StatusCode(500);
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] Guid id)
        {
            var result = await _accountLogic.DeleteEmployee(id);

            if (!result)
            {
                return StatusCode(500);
            }

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeInfo([FromRoute] Guid id)
        {
            var result = _accountLogic.GetEmployee(id);
            return Content(JsonConvert.SerializeObject(result), "application/json");
        }
    }
}
