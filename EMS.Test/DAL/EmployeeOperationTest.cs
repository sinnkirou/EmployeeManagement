using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMS.DAL;
using EMS.Model;
using System.Collections.Generic;

namespace EMS.Test.DAL
{
    [TestClass]
    public class EmployeeOperationTest
    {
        [TestMethod]
        public void CreateEmployee_noOtherRecord()
        {
            EmployeeOperation emploeeCreation = new EmployeeOperation();
            Employee employee = new Employee();
            employee.FirstName = "test";
            employee.LastName = "demo";
            employee.Gender = "M";
            employee.Phone = "13454521622";
            employee.Address = "Beijing";
            employee.Birth = Convert.ToDateTime("1998-1-1");

            bool result = emploeeCreation.CreateEmployee(employee);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateEmployee_hasRecords()
        {
            EmployeeOperation emploeeCreation = new EmployeeOperation();
            Employee employee = new Employee();
            employee.FirstName = "test";
            employee.LastName = "demo";
            employee.Gender = "M";
            employee.Phone = "13454521622";
            employee.Address = "Beijing";
            employee.Birth = Convert.ToDateTime("1998-1-1");
            new EmployeeDataEntity();

            bool result = emploeeCreation.CreateEmployee(employee);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteEmployee_WithNonExistentId()
        {
            int employeeId = 101;
            EmployeeOperation employeeOperation = new EmployeeOperation();

            bool result = employeeOperation.DeleteEmployee(employeeId);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeleteEmployee_WithExistentId()
        {
            int employeeId = 101;
            EmployeeOperation employeeOperation = new EmployeeOperation();

            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();
            bool result = employeeOperation.DeleteEmployee(employeeId);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateEmployee_WithFullUpdate()
        {
            EmployeeOperation employeeOperation = new EmployeeOperation();
            Employee employeeItem = new Employee();
            employeeItem.EmployeeId = 101;
            employeeItem.Address = "updatedPlace";
            employeeItem.Birth = Convert.ToDateTime("2016-1-1");
            employeeItem.Phone = "13412345678";
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();

            bool result = employeeOperation.UpdateEmployee(employeeItem);
            EmployeeDataEntity.EmployeeBase.Clear();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateEmployee_WithNonExistentEmployee()
        {
            EmployeeOperation employeeOperation = new EmployeeOperation();
            Employee employeeItem = new Employee();
            employeeItem.EmployeeId = 199;

            bool result = employeeOperation.UpdateEmployee(employeeItem);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateEmployee_WithExistentEmployee()
        {
            EmployeeOperation employeeOperation = new EmployeeOperation();
            Employee employeeItem = new Employee();
            employeeItem.EmployeeId = 101;
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();

            bool result = employeeOperation.UpdateEmployee(employeeItem);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetEmployeeSearchResult_WithNoCondition()
        {
            EmployeeOperation employeeOperation = new EmployeeOperation();
            Employee employeeConditon = new Employee();

            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();
            List<Employee> listResult = employeeOperation.GetEmployeeSearchResult(employeeConditon);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.AreEqual(3, listResult.Count);
        }

        [TestMethod]
        public void GetEmployeeSearchResult_WithNonExistentId()
        {
            EmployeeOperation employeeOperation = new EmployeeOperation();
            Employee employeeConditon = new Employee();
            employeeConditon.EmployeeId = 199;
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();

            List<Employee> listResult = employeeOperation.GetEmployeeSearchResult(employeeConditon);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.AreEqual(0, listResult.Count);
        }

        [TestMethod]
        public void GetEmployeeSearchResult_WithNonExistentFirstName()
        {
            EmployeeOperation employeeOperation = new EmployeeOperation();
            Employee employeeConditon = new Employee();
            employeeConditon.FirstName = "test";
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();

            List<Employee> listResult = employeeOperation.GetEmployeeSearchResult(employeeConditon);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.AreEqual(0, listResult.Count);
        }

        [TestMethod]
        public void GetEmployeeSearchResult_WithNonExistentLastName()
        {
            EmployeeOperation employeeOperation = new EmployeeOperation();
            Employee employeeConditon = new Employee();
            employeeConditon.LastName = "test";
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();

            List<Employee> listResult = employeeOperation.GetEmployeeSearchResult(employeeConditon);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.AreEqual(0, listResult.Count);
        }

        [TestMethod]
        public void GetEmployeeSearchResult_WithExistentId()
        {
            EmployeeOperation employeeOperation = new EmployeeOperation();
            Employee employeeConditon = new Employee();
            employeeConditon.EmployeeId = 101;
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();

            List<Employee> listResult = employeeOperation.GetEmployeeSearchResult(employeeConditon);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.AreEqual(1, listResult.Count);
            Assert.AreEqual(101, listResult[0].EmployeeId);
        }

        [TestMethod]
        public void GetEmployeeSearchResult_WithExistentFirstName()
        {
            EmployeeOperation employeeOperation = new EmployeeOperation();
            Employee employeeConditon = new Employee();
            employeeConditon.FirstName = "ziv";
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();

            List<Employee> listResult = employeeOperation.GetEmployeeSearchResult(employeeConditon);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.AreEqual(1, listResult.Count);
            Assert.AreEqual("Ziv", listResult[0].FirstName);
        }

        [TestMethod]
        public void GetEmployeeSearchResult_WithExistentLastName()
        {
            EmployeeOperation employeeOperation = new EmployeeOperation();
            Employee employeeConditon = new Employee();
            employeeConditon.LastName = "zh";
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();

            List<Employee> listResult = employeeOperation.GetEmployeeSearchResult(employeeConditon);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.AreEqual(2, listResult.Count);
            Assert.AreEqual("Zhao", listResult[0].LastName);
            Assert.AreEqual("Zha", listResult[1].LastName);
        }

        [TestMethod]
        public void GetEmployeeSearchResult_WithFullExistentConditon()
        {
            EmployeeOperation employeeSearch = new EmployeeOperation();
            Employee employeeConditon = new Employee();
            employeeConditon.EmployeeId = 101;
            employeeConditon.LastName = "zh";
            employeeConditon.FirstName = "ziv";
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();

            List<Employee> listResult = employeeSearch.GetEmployeeSearchResult(employeeConditon);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.AreEqual(1, listResult.Count);
            Assert.AreEqual("Zhao", listResult[0].LastName);
        }

        [TestMethod]
        public void CheckEmployeeExist_WithNonExistentId()
        {
            EmployeeOperation employeeOperation = new EmployeeOperation();
            int employeeId = 101;

            bool result = employeeOperation.CheckEmployeeExist(employeeId);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckEmployeeExist_WithExistentId()
        {
            EmployeeOperation employeeOperation = new EmployeeOperation();
            int employeeId = 101;

            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();
            bool result = employeeOperation.CheckEmployeeExist(employeeId);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Clone_test()
        {
            Employee clonedEmployee = new Employee();
            clonedEmployee.EmployeeId = 199;

            Employee result = EmployeeOperation.Clone<Employee>(clonedEmployee);

            Assert.AreEqual(clonedEmployee.EmployeeId, result.EmployeeId);
        }
    }
}
