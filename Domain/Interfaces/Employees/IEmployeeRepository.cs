using Domain.Entities.Employees;
using Domain.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Employees
{
    public interface IEmployeeRepository
    {
        Task<EmployeeModel> InsertAsync(EmployeeModel model);
        Task<EmployeeModel> UpdateAsync(EmployeeModel model);
        Task<EmployeeModel> DeleteAsync(Guid id);
        Task<EmployeeModel> Get(Guid employeeId);
        Task<IEnumerable<EmployeeModel>> GetAll();
    }
}
