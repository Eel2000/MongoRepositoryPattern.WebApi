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
    public class DepartementController : ControllerBase
    {
        private readonly IDepartementRepositoryAsync departementRepository;

        public DepartementController(IDepartementRepositoryAsync departementRepository)
        {
            this.departementRepository = departementRepository;
        }

        [HttpGet("get-all-departement")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await departementRepository.ToListAsync());
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
                var dpt = new Departement
                {
                    Name = departement.Name
                };
                await departementRepository.AddAsync(dpt);
                return Ok("Departement has bee added successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
    }
}
