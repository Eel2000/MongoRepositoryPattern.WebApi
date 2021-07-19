using MongoRepositoryPattern.Context;
using MongoRepositoryPattern.Models;
using MongoRepositoryPattern.Repositories.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRepositoryPattern.Repositories.Domain
{
    public class EmployeeRepositoryAsync : BaseRepository<Employee>, IEmployeeRepositoryAsync
    {
        public EmployeeRepositoryAsync(IMongoContext context) : base(context)
        {
        }
    }
}
