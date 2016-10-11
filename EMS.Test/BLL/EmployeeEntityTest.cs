using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMS.BLL;
using EMS.Model;
using EMS.DAL;
using System.Collections.Generic;

namespace EMS.Test.BLL
{
    [TestClass]
    public class EmployeeEntityTest
    {
        [TestMethod]
        public void CreateEmployee()
        {
            EmployeeEntity employeeCreationBLL = new EmployeeEntity();
            Employee employee = new Employee();
            employee.FirstName = "test";
            employee.LastName = "demo";
            employee.Gender = "M";
            employee.Phone = "13454521622";
            employee.Address = "Beijing";
            employee.Birth = Convert.ToDateTime("1998-1-1");

            bool result = employeeCreationBLL.CreateEmployee(employee);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteEmployee_withExistentId()
        {
            EmployeeEntity employeeEntity = new EmployeeEntity();
            int employeeId = 101;
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();

            bool result = employeeEntity.DeleteEmployee(employeeId);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteEmployee_withNonExistentId()
        {
            EmployeeEntity employeeEntity = new EmployeeEntity();
            int employeeId = 199;
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();

            bool result = employeeEntity.DeleteEmployee(employeeId);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateEmployee_withExistentEmployee()
        {
            EmployeeEntity employeeEntity = new EmployeeEntity();
            Employee employeeToUpate = new Employee();
            employeeToUpate.EmployeeId = 101;
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();

            bool result = employeeEntity.UpdateEmployee(employeeToUpate);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateEmployee_withNonExistentEmployee()
        {
            EmployeeEntity employeeEntity = new EmployeeEntity();
            Employee employeeToUpate = new Employee();
            employeeToUpate.EmployeeId = 199;
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();

            bool result = employeeEntity.UpdateEmployee(employeeToUpate);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FuzzySearchEmployee_withExistentEmployee()
        {
            EmployeeEntity employeeEntity = new EmployeeEntity();
            Employee employeeCondition = new Employee();
            employeeCondition.EmployeeId = 101;
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();

            List<Employee> result = employeeEntity.FuzzySearchEmployee(employeeCondition);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(101, result[0].EmployeeId);
        }

        [TestMethod]
        public void FuzzySearchEmployee_withNonExistentEmployee()
        {
            EmployeeEntity employeeEntity = new EmployeeEntity();
            Employee employeeCondition = new Employee();
            employeeCondition.EmployeeId = 199;
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();

            List<Employee> result = employeeEntity.FuzzySearchEmployee(employeeCondition);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void PreciceSearchEmployee_withExistentEmployee()
        {
            EmployeeEntity employeeEntity = new EmployeeEntity();
            int employeeId = 101;
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();

            List<Employee> result = employeeEntity.PreciceSearchEmployee(employeeId);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(101, result[0].EmployeeId);
        }

        [TestMethod]
        public void PreciceSearchEmployee_WithNonExistentId()
        {
            EmployeeEntity employeeEntity = new EmployeeEntity();
            int employeeId = 199;
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();

            List<Employee> result = employeeEntity.PreciceSearchEmployee(employeeId);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.IsNull(result);
        }
    }
}
