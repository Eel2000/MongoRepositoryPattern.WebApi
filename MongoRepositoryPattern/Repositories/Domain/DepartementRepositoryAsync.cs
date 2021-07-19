using MongoRepositoryPattern.Context;
using MongoRepositoryPattern.DTOs;
using MongoRepositoryPattern.Models;
using MongoRepositoryPattern.Repositories.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRepositoryPattern.Repositories.Domain
{
    public class DepartementRepositoryAsync : BaseRepository<Departement>, IDepartementRepositoryAsync
    {
        public DepartementRepositoryAsync(IMongoContext context) : base(context)
        {
        }

        public Task<object> AddAsync(DepartementDto departement)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<object> GetbyId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
