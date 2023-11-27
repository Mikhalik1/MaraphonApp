using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MaraphonApp;
using MaraphonApp.Controllers;
using MaraphonApp.Models;

namespace LoginPageTests

{
    [TestClass]
    public class LoginTest
    {
        Corebd context = new Corebd();
        [TestMethod]
        public void TestMethod1()
        {
            string Email = "bbo@gmail.com";
            string Password = "MasterGosha";
            UserController us = new UserController();
            bool result = us.Login(Email, Password);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            string Email = "bbwadao@gmail.com";
            string Password = "MasterGosha";
            UserController us = new UserController();
            bool result = us.Login(Email, Password);
            Assert.IsFalse(result);
        }
    }
}
