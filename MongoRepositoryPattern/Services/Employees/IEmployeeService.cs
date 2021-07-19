using MongoRepositoryPattern.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRepositoryPattern.Services.Employees
{
    public interface IEmployeeService
    {
        Task<object> GetAll();
        Task<object> GetOne(string id);
        Task<object> UpdateEmployee(EmployeeDto employee);
        Task<object> CreateEmployee(EmployeeDto employee);
        Task<object> DeleteEmployee(string id);
    }
}
