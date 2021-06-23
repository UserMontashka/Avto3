using System;
using Avto.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject.Models;

namespace TestProject
{
    [TestClass]
    public class Login
    {
        public Core db = new Core();
        [TestMethod]
        public void ChecktLogin_ExistLogin_isTrue()
        {
            //Arrange
            string login = "1";

            //Act
            UserController ExistLogin = new UserController();
            bool result = ExistLogin.CheckLogin(login);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ChecktLogin_NoExistLogin_isTrue()
        {
            //Arrange
            string login = "1245";

            //Act
            UserController ExistLogin = new UserController();
            bool result = ExistLogin.CheckLogin(login);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ChecktLogin_Null_isTrue()
        {
            //Arrange
            string login = "";

            //Act
            UserController ExistLogin = new UserController();
            bool result = ExistLogin.CheckLogin(login);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ChecktPass_ExistPass_isTrue()
        {
            //Arrange
            string pass = "1111";

            //Act
            UserController ExistPass = new UserController();
            bool result = ExistPass.CheckPassword(pass);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ChecktPass_NoExistPass_isTrue()
        {
            //Arrange
            string pass = "1234523453";

            //Act
            UserController ExistPass = new UserController();
            bool result = ExistPass.CheckPassword(pass);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ChecktPass_Null_isTrue()
        {
            //Arrange
            string pass = "";

            //Act
            UserController ExistPass = new UserController();
            bool result = ExistPass.CheckPassword(pass);
            //Assert
            Assert.IsFalse(result);
        }
    }
}
