using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagementMVC.Controllers;

namespace ProductManagementMVC.Tests.Controllers
{
    [TestClass]
    public class AuthenticationControllerTest
    {
        [TestMethod]
        public void Login()
        {
            // Arrange
             AuthenticationController controller = new AuthenticationController();

            // Act
            ViewResult result = controller.Login() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Register()
        {
            // Arrange
            AuthenticationController controller = new AuthenticationController();

            // Act
            ViewResult result = controller.Register() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
