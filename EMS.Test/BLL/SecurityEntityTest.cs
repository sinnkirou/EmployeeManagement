using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMS.BLL;
using EMS.DAL;

namespace EMS.Test.BLL
{
    [TestClass]
    public class SecurityEntityTest
    {
        [TestMethod]
        public void Login_withExistentEmployee()
        {
            SecurityEntity employeeLogin = new SecurityEntity();
            int employeeId = 101;
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();

            bool result = employeeLogin.Login(employeeId);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Login_withNonExistentEmployee()
        {
            SecurityEntity employeeLogin = new SecurityEntity();
            int employeeId = 199;
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();

            bool result = employeeLogin.Login(employeeId);
            EmployeeDataEntity.EmployeeBase.Clear();

            Assert.IsFalse(result);
        }
    }
}
