using MongoDB.Bson.Serialization.Attributes;
using MongoRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRepositoryPattern.DTOs
{
    public class EmployeeDto
    {
        public string Nom { get; set; }
        public string Postnom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public EtatCivil? EtatCivil { get; set; }

        [BsonRequired]
        public string IdDepartement { get; set; }
        [BsonRequired]
        public string IdTitle { get; set; }
    }
}
