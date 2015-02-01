using Lecture13;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Lecture13.B
{

    public class TestDataBase : IDataBase
    {

        public List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee { Name="abc" },
                new Employee { Name="def" },
                new Employee { Name="fgh" }
            };
        }
    }
    
    [TestClass]
    public class Test1
    {


        [TestMethod]
        public void FilterTest()
        {
            var db = new TestDataBase();
            var finder = new EmployeeFinder(db);
            var emps = finder.Filter("e");
            Assert.AreEqual(1, emps.Count);

        }
    }
}
