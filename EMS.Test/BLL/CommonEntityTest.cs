using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMS.BLL;

namespace EMS.Test.BLL
{
    [TestClass]
    public class CommonEntityTest
    {
        [TestMethod]
        public void CaptializedName_test()
        {
            CommonEntity commonEntity = new CommonEntity();

            string result = commonEntity.CaptializedName("test");

            Assert.AreEqual("Test", result);
        }

        [TestMethod]
        public void IsValidId_valid()
        {
            CommonEntity commonEntity = new CommonEntity();

            bool result = commonEntity.IsValidId("111");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidId_invalid()
        {
            CommonEntity commonEntity = new CommonEntity();

            bool result = commonEntity.IsValidId("test");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidName_valid()
        {
            CommonEntity commonEntity = new CommonEntity();

            bool result = commonEntity.IsValidName("test");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidName_invalid()
        {
            CommonEntity commonEntity = new CommonEntity();

            bool result = commonEntity.IsValidName("");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidGender_valid()
        {
            CommonEntity commonEntity = new CommonEntity();

            bool result = commonEntity.IsValidGender("M");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidGender_invalid()
        {
            CommonEntity commonEntity = new CommonEntity();

            bool result = commonEntity.IsValidGender("");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidBirthday_valid()
        {
            CommonEntity commonEntity = new CommonEntity();

            bool result = commonEntity.IsValidBirthday("2011-1-1");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidBirthday_invalid()
        {
            CommonEntity commonEntity = new CommonEntity();

            bool result = commonEntity.IsValidBirthday("");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidPhone_valid()
        {
            CommonEntity commonEntity = new CommonEntity();

            bool result = commonEntity.IsValidPhone("13454521234");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidPhone_invalid()
        {
            CommonEntity commonEntity = new CommonEntity();

            bool result = commonEntity.IsValidPhone("");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidAddress_valid()
        {
            CommonEntity commonEntity = new CommonEntity();

            bool result = commonEntity.IsValidAddress("");

            Assert.IsTrue(result);
        }
    }
}
