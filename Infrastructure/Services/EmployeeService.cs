using AutoMapper;
using Domain.Entities.Employees;
using Domain.Interfaces;
using Domain.Interfaces.EmployeeModels;
using Domain.Interfaces.Employees;
using Domain.Models.Employees;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, ILogger logger, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<EmployeeModel> InsertAsync(EmployeeModel model)
        {
            var result = await _employeeRepository.InsertAsync(model);
            if (result != null)
            {
                _logger.Information("A new employee has been added");
            }
            return result;
        }

        public async Task<EmployeeModel> UpdateAsync(EmployeeModel model)
        {
            var result = await _employeeRepository.UpdateAsync(model);
            return result;
        }

        public async Task<EmployeeModel> DeleteAsync(Guid id)
        {
            var result = await _employeeRepository.DeleteAsync(id);
            return result;
        }

        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            var result = await _employeeRepository.GetAll();
            return result;
        }

        public async Task<EmployeeModel> Get(Guid id)
        {
            var result = await _employeeRepository.Get(id);
            return result;
        }
    }
}
