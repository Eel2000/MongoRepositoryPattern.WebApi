using MongoRepositoryPattern.DTOs;
using MongoRepositoryPattern.Models;
using MongoRepositoryPattern.Repositories.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRepositoryPattern.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepositoryAsync _employeeRepository;
        public EmployeeService(IEmployeeRepositoryAsync employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<object> CreateEmployee(EmployeeDto employee)
        {
            var emp = new Employee
            {
                Nom = employee.Nom,
                Postnom = employee.Postnom,
                Prenom = employee.Prenom,
                Telephone = employee.Telephone,
                Email = employee.Email,
                EtatCivil = employee.EtatCivil,
                IdDepartement = employee.IdDepartement,
                IdTitle = employee.IdTitle
            };

            await _employeeRepository.AddAsync(emp);
            return new
            {
                status = "SUCCESS",
                message = "new employee has been added successfully",
                data = emp
            };
        }

        public async Task<object> DeleteEmployee(string id)
        {
            var deletedEmp = await _employeeRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (ReferenceEquals(deletedEmp, null)) throw new EntryPointNotFoundException("this id doesn't connect to any employee");

            await _employeeRepository.Remove(x => x.Id == id);
            return new
            {
                status = "SUCCESS",
                message = "employee has been deleted successfully",
                data = deletedEmp
            };
        }

        public async Task<object> GetAll()
        {
            var employees = await _employeeRepository.ToListAsync();

            return new
            {
                status = "SUCCESS",
                message = $"Employees found {employees.Count}",
                data = employees
            };
        }

        public Task<object> GetOne(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<object> UpdateEmployee(EmployeeDto employee)
        {
            var emp = new Employee
            {
                Id = employee.Id,
                Nom = employee.Nom,
                Postnom = employee.Postnom,
                Prenom = employee.Prenom,
                Telephone = employee.Telephone,
                Email = employee.Email,
                EtatCivil = employee.EtatCivil,
                IdDepartement = employee.IdDepartement,
                IdTitle = employee.IdTitle
            };

            await _employeeRepository.UpdateAsync(x => x.Id == employee.Id, emp);

            return new
            {
                status = "SUCCESS",
                message = "employee has been updated",
                data = emp
            };
        }
    }
}
