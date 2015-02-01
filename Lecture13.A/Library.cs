using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lecture13
{
    public class Employee
    {
        public string Name { get; set; }
    }

    public interface IDataBase
    {
        List<Employee> GetEmployees();
    }

    public class EmployeeFinder
    {
        IDataBase database;

        public EmployeeFinder(IDataBase database)
        {
            this.database=database;
        }

        public List<Employee> Filter(string query)
        {
            return database.GetEmployees().Where(z => query.Length<2 || z.Name.Contains(query) ).ToList();
        }
    }

}