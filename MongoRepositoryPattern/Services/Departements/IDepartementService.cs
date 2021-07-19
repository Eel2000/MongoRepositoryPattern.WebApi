using MongoRepositoryPattern.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRepositoryPattern.Services.Departements
{
    public interface IDepartementService
    {
        Task<object> GetAllAsync();
        Task<object> CreateAsync(DepartementDto departement);
        Task<object> UpdateDepartement(DepartementDto departement);
        Task<object> DeleteDepartement(string id);
    }
}
