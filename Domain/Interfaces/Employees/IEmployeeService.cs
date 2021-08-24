using Domain.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.EmployeeModels
{
    public interface IEmployeeService
    {
        Task<EmployeeModel> InsertAsync(EmployeeModel model);
        Task<EmployeeModel> UpdateAsync(EmployeeModel model);
        Task<EmployeeModel> DeleteAsync(Guid id);
        Task<IEnumerable<EmployeeModel>> GetAll();
        Task<EmployeeModel> Get(Guid id);
    }
}
