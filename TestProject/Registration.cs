using System;
using Avto.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class Registration
    {
        [TestMethod]
        public void ChecktPasport_Correct_isTrue()
        {
            //Arrange
            string pasport = "4575658612";

            //Act
            UserController objpasport = new UserController();
            bool result = objpasport.TextPaspportNumber(pasport);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ChecktPasport_NoCorrectLeght_isFalse()
        {
            //Arrange
            string pasport = "45756586";

            //Act
            UserController objpasport = new UserController();
            bool result = objpasport.TextPaspportNumber(pasport);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ChecktPasport_NoCorrectSymbol_isFalse()
        {
            //Arrange
            string pasport = "4575as6586";

            //Act
            UserController objpasport = new UserController();
            bool result = objpasport.TextPaspportNumber(pasport);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ChecktUdost_Correct_isTrue()
        {
            //Arrange
            string udost = "123456-12";

            //Act
            UserController objudost = new UserController();
            bool result = objudost.TextUdostoverenie(udost);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ChecktUdost_NoCorrectLeght_isFalse()
        {
            //Arrange
            string udost = "123456-1";

            //Act
            UserController objudost = new UserController();
            bool result = objudost.TextUdostoverenie(udost);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ChecktUdost_NoCorrectSymbol_isFalse()
        {
            //Arrange
            string udost = "123456sda";

            //Act
            UserController objudost = new UserController();
            bool result = objudost.TextUdostoverenie(udost);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ChecktUdost_NoCorrectFormat_isFalse()
        {
            //Arrange
            string udost = "12345612";

            //Act
            UserController objudost = new UserController();
            bool result = objudost.TextUdostoverenie(udost);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ChecktGosNumber_Correct_isTrue()
        {
            //Arrange
            string gos = "A123AA-12";

            //Act
            UserController objgosnumber = new UserController();
            bool result = objgosnumber.TextGosNumber(gos);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ChecktGosNumber_NoCorrectLeght_isFalse()
        {
            //Arrange
            string gos = "A123AA-1";

            //Act
            UserController objgosnumber = new UserController();
            bool result = objgosnumber.TextGosNumber(gos);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ChecktGosNumber_NoCorrectFormat1_isFalse()
        {
            //Arrange
            string gos = "A123Aa-12";

            //Act
            UserController objgosnumber = new UserController();
            bool result = objgosnumber.TextGosNumber(gos);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ChecktGosNumber_NoCorrectFormat2_isFalse()
        {
            //Arrange
            string gos = "A1A3AA-12";

            //Act
            UserController objgosnumber = new UserController();
            bool result = objgosnumber.TextGosNumber(gos);
            //Assert
            Assert.IsFalse(result);
        }
       
    }
}
