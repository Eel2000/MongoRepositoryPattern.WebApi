using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRepositoryPattern.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
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

    public enum EtatCivil
    {
        Marie = 1,
        Celibataire = 2,
        Divorce = 3,
        Veuve_Veuf = 4,
    }
}
