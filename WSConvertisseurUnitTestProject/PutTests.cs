using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSConvertisseur.Controllers;
using WSConvertisseur.Models;

namespace WSConvertisseurUnitTestProject
{
    [TestClass]
    public class PutTests
    {
        [TestMethod]
        public void Put_ExistingIdPassed_ReturnsOkObjectResult()
        {
            // Arrange
            var _controller = new MottoController();
            // Act
            var result = _controller.Put(1, new Motto(1, "Test", 1.03)) as OkObjectResult;
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult), "Pas un OkObjectResult");
        }

        [TestMethod]
        public void Put_UnknownGuidPassed_ReturnsBadRequestResult()
        {
            // Arrange
            var _controller = new MottoController();
            // Act
            var result = _controller.Put(4, new Motto(1, "Test", 1.03));
            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult), "Pas un BadRequestResult");
        }

        [TestMethod]
        public void Put_ExistingPassed_ReturnsRightItem()
        {
            // Arrange
            var _controller = new MottoController();
            // Act
            var result = _controller.Put(1, new Motto(1, "Test", 1.03)) as OkObjectResult;
            // Assert
            Assert.IsInstanceOfType(result.Value, typeof(Motto), "Pas une Devise");
            Assert.AreEqual(new Motto(1, "Test", 1.03), (Motto)result.Value, "Devises pas identiques");
        }
    }
}