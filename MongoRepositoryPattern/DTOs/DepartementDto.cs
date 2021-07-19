using MongoRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRepositoryPattern.DTOs
{
    public class DepartementDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int EmployeesNumber { get; set; }
        //public IList<Employee> Employees { get; set; }
        //public IList<Title> Titles { get; set; }
    }
}
