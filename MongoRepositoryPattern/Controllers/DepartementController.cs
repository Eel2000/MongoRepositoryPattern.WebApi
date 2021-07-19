using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoRepositoryPattern.DTOs;
using MongoRepositoryPattern.Models;
using MongoRepositoryPattern.Repositories.Domain.Interfaces;
using MongoRepositoryPattern.Services.Departements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRepositoryPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartementController : ControllerBase
    {
        private readonly IDepartementService _departementService;

        public DepartementController(IDepartementService departementServices)
        {
            _departementService = departementServices;
        }

        [HttpGet("get-all-departement")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _departementService.GetAllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpPost("add-new-departement")]
        public async Task<IActionResult> AddAsync([FromBody] DepartementDto departement)
        {
            try
            {
                return Ok(await _departementService.CreateAsync(departement));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpDelete("delete-departement")]
        public async Task<IActionResult> DeleteDepartement([FromQuery] string id)
        {
            try
            {
                return Ok(await _departementService.DeleteDepartement(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpPut("update-departement")]
        public async Task<IActionResult> Update([FromBody] DepartementDto departementDto)
        {
            try
            {
                return Ok(await _departementService.UpdateDepartement(departementDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
    }
}
