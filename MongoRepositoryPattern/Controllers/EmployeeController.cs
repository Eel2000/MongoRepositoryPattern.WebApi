using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoRepositoryPattern.DTOs;
using MongoRepositoryPattern.Models;
using MongoRepositoryPattern.Repositories.Domain.Interfaces;
using MongoRepositoryPattern.Services.Employees;
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
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("get-all-employees")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _employeeService.GetAll());
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
                return Ok(await _employeeService.CreateEmployee(employee));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpPut("update-emplyee")]
        public async Task<IActionResult> UpdateAsync([FromBody] EmployeeDto employee)
        {
            try
            {
                return Ok(await _employeeService.UpdateEmployee(employee));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpDelete("delete-employee")]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            try
            {
                return Ok(await _employeeService.DeleteEmployee(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
    }
}
