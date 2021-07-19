using MongoRepositoryPattern.DTOs;
using MongoRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRepositoryPattern.Repositories.Domain.Interfaces
{
    public interface IDepartementRepositoryAsync : IBaseRepository<Departement>
    {
        Task<object> GetAll();
        Task<object> GetbyId(string id);
        Task<object> AddAsync(DepartementDto departement);
    }
}
