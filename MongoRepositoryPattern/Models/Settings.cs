using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRepositoryPattern.Models
{
    public class Settings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
