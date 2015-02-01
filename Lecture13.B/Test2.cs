using Lecture13;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Lecture13.B
{

    
    [TestClass]
    public class Test2
    {



        [TestMethod]
        public void FilterTest()
        {
            var db = new Moq.Mock<IDataBase>();
            db
                .Setup(z => z.GetEmployees())
                .Returns(new List<Employee>
                   {
                   new Employee { Name="abc" },
                   new Employee { Name="def" },
                   new Employee { Name="fgh" }
                   });

            var finder = new EmployeeFinder(db.Object);
            var emps = finder.Filter("e");
            Assert.AreEqual(1, emps.Count);

        }
    }
}
