using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.EmployeeModels;
using Domain.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Logics
{
    public class AccountLogic :IAccountLogic
    {
        private readonly IEmployeeService _employeeService;
        private readonly IFileService _fileService;
        public AccountLogic(IEmployeeService employeeService, IFileService fileService)
        {
            _employeeService = employeeService;
            _fileService = fileService;
        }
        public async Task<bool> CreateEmployee(EmployeeModel model)
        {
            var types = new[] { "image/jpeg", "image/jpg", "image/png" };

            if (!types.Contains(model.Avatar.ContentType) || model == null)
            {
                return false;
            }

            model.Id = Guid.NewGuid();

            await _fileService.SaveImageAsync(model.Avatar, model.Id);

            var result = await _employeeService.InsertAsync(model);
            return result != null;
        }

        public async Task<bool> UpdateEmployee(EmployeeModel model)
        {
            var types = new[] { "image/jpeg", "image/jpg", "image/png" };

            if (model.Avatar != null && types.Contains(model.Avatar.ContentType))
            {
                await _fileService.SaveImageAsync(model.Avatar, model.Id);
            }

            var result = await _employeeService.UpdateAsync(model);
            return result != null;
        }

        public async Task<bool> DeleteEmployee(Guid id)
        {
            var result = await _employeeService.DeleteAsync(id);
            if (result != null)
            {
                _fileService.DeleteImageAsync(id);
            }

            return result != null;
        }

        public EmployeeModel GetEmployee(Guid id)
        {
            var employee = _employeeService.Get(id);
            EmployeeModel result = employee.Result;
            return result;
        }
    }
}
