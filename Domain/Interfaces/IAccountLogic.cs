using Domain.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAccountLogic
    {
        Task<bool> CreateEmployee(EmployeeModel model);
        Task<bool> UpdateEmployee(EmployeeModel model);
        Task<bool> DeleteEmployee(Guid id);
        EmployeeModel GetEmployee(Guid id);
    }
}
