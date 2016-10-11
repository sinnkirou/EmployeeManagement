using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMS.Model;

namespace EMS.Test.Model
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void CompareTo_withNullEmployee()
        {
            Employee employee = new Employee();
            Employee employeeTobeCompared = null;

            int result = employee.CompareTo(employeeTobeCompared);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CompareTo_withExistentEmployee()
        {
            Employee employee = new Employee();
            employee.EmployeeId = 101;
            Employee employeeTobeCompared = new Employee();
            employeeTobeCompared.EmployeeId = 102;

            int result = employee.CompareTo(employeeTobeCompared);

            Assert.AreEqual(-1, result);
        }


    }
}
