using AutoMapper;
using Domain.Entities.Employees;
using Domain.Interfaces;
using Domain.Interfaces.Employees;
using Domain.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class EmployeeRepository :BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly IMapper _mapper;
        public EmployeeRepository(string connectionString, IMapper mapper)
               : base(connectionString)
        {
            _mapper = mapper;
        }

        public async Task<EmployeeModel> InsertAsync(EmployeeModel model)
        {
            var sqlQuery = $"INSERT INTO \"Employee\" (\"Id\", \"FirstName\", \"SecondName\", \"LastName\", \"DateOfBirth\", \"Position\") VALUES ('{model.Id}', '{model.FirstName}', '{model.SecondName}','{model.LastName}', '{model.DateOfBirth.ToShortDateString()}', '{model.Position}') returning *";
            var result = await GetEnemyAsync(sqlQuery);
            return _mapper.Map<EmployeeModel>(result);
        }

        public async Task<EmployeeModel> UpdateAsync(EmployeeModel model)
        {
            var sqlQuery = $"UPDATE \"Employee\" SET \"FirstName\"='{model.FirstName}', \"SecondName\"='{model.SecondName}', \"LastName\"='{model.LastName}', \"DateOfBirth\"='{model.DateOfBirth.ToShortDateString()}', \"Position\"='{model.Position}' WHERE \"Id\" = '{model.Id}' returning *";
            var result = await GetEnemyAsync(sqlQuery);
            return _mapper.Map<EmployeeModel>(result);
        }

        public async Task<EmployeeModel> DeleteAsync(Guid id)
        {
            var sqlQuery = $"DELETE FROM \"Employee\" WHERE \"Id\" = '{id}'  returning *";
            var result = await GetEnemyAsync(sqlQuery);
            return _mapper.Map<EmployeeModel>(result);
        }

        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            var sqlQuery = "SELECT * FROM \"Employee\" ORDER BY \"FirstName\"";
            var result = await GetListAsync(sqlQuery);
            return _mapper.Map<IEnumerable<EmployeeModel>>(result);
        }

        public async Task<EmployeeModel> Get(Guid employeeId)
        {
            var sqlQuery = $"SELECT * FROM \"Employee\" WHERE \"Id\" = '{employeeId}'";
            var result = await GetEnemyAsync(sqlQuery);
            return _mapper.Map<EmployeeModel>(result);
        }
    }
}
