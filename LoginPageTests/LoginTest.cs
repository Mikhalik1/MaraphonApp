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
        public void testlogin_true()
        {
            string Email = "bbo@gmail.com";
            string Password = "MasterGosha";
            UserController us = new UserController();
            bool result = us.Login(Email, Password);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void testlogin_false()
        {
            string Email = "bbwadao@gmail.com";
            string Password = "MasterGosha";
            UserController us = new UserController();
            bool result = us.Login(Email, Password);
            Assert.IsFalse(result);
        }
    }
}
