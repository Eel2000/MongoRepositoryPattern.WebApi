using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoRepositoryPattern.DTOs;
using MongoRepositoryPattern.Models;
using MongoRepositoryPattern.Repositories.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepositoryAsync employeeRepository;

        public EmployeeController(IEmployeeRepositoryAsync employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet("get-all-employees")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await employeeRepository.ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpPost("add-new-employee")]
        public async Task<IActionResult> AddAsync([FromBody] EmployeeDto employee)
        {
            try
            {
                var emp = new Employee
                {
                    Nom = employee.Nom,
                    Postnom = employee.Postnom,
                    Prenom = employee.Prenom,
                    Email = employee.Email,
                    EtatCivil = employee.EtatCivil,
                    Telephone = employee.Telephone,
                    IdDepartement = employee.IdDepartement
                };

                await employeeRepository.AddAsync(emp);
                return Ok("new employee added successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpPut("update-emplyee")]
        public async Task<IActionResult> UpdateAsync([FromBody] EmployeeDto employee, string id)
        {
            try
            {
                var emp = new Employee
                {
                    Id = id,
                    Nom = employee.Nom,
                    Postnom = employee.Postnom,
                    Prenom = employee.Prenom,
                    Email = employee.Email,
                    EtatCivil = employee.EtatCivil,
                    Telephone = employee.Telephone,
                    IdDepartement = employee.IdDepartement
                };

                await employeeRepository.UpdateAsync(x => x.Id == id, emp);

                return Ok(await employeeRepository.FirstOrDefaultAsync(x=>x.Id == id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
    }
}
