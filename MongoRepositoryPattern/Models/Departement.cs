using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRepositoryPattern.Models
{
    public class Departement
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int EmployeesNumber { get; set; }
        public IList<Employee> Employees { get; set; }
        public IList<Title> Titles { get; set; }
    }
}
