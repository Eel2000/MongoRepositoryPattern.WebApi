using MongoRepositoryPattern.DTOs;
using MongoRepositoryPattern.Models;
using MongoRepositoryPattern.Repositories.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRepositoryPattern.Services.Departements
{
    public class DepartementServices : IDepartementService
    {

        private readonly IDepartementRepositoryAsync _departementRepository;
        public DepartementServices(IDepartementRepositoryAsync departementRepository)
        {
            _departementRepository = departementRepository;
        }

        public async Task<object> CreateAsync(DepartementDto departement)
        {
            var dpt = new Departement
            {
                Name = departement.Name
            };
            await _departementRepository.AddAsync(dpt);

            return new
            {
                status = "SUCCESS",
                message = "departement added successfully"
            };
        }

        public async Task<object> DeleteDepartement(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("id is invalid");

            var deletedDep = await _departementRepository.FirstOrDefaultAsync(x => x.Id == id);
            await _departementRepository.Remove(x => x.Id == id);

            return new
            {
                status = "SUCCESS",
                message = "Departement deleted successfully",
                data = deletedDep
            };
        }

        public async Task<object> GetAllAsync()
        {
            var deps = await _departementRepository.ToListAsync();
            return new
            {
                status = "SUCCESS",
                message = $"Depertaments found{deps.Count}",
                data = deps.OrderBy(x => x.Name)
            };
        }

        public async Task<object> UpdateDepartement(DepartementDto departement)
        {
            var dep = new Departement
            {
                Id = departement.Id,
                Name = departement.Name,
                EmployeesNumber = departement.EmployeesNumber
            };
            await _departementRepository.UpdateAsync(x => x.Id == departement.Id, dep);

            return new
            {
                status = "SUCCESS",
                message = "departement has been updated successfully",
                data = await _departementRepository.FirstOrDefaultAsync(x => x.Id == departement.Id)
            };
        }
    }
}
