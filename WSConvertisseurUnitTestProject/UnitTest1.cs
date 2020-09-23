using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSConvertisseur.Controllers;
using WSConvertisseur.Models;

namespace WSConvertisseurUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsOkObjectResult()
        {
            // Arrange
            var _controller = new MottoController();
            // Act
            var result = _controller.GetById(1) as OkObjectResult;
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult), "Pas un OkObjectResult");
        }

        [TestMethod]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Arrange
            var _controller = new MottoController();
            // Act
            var result = _controller.GetById(20);
            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult), "Pas un NotFoundResult");
        }

        [TestMethod]
        public void GetById_ExistingPassed_ReturnsRightItem()
        {
            // Arrange
            var _controller = new MottoController();
            // Act
            var result = _controller.GetById(1) as OkObjectResult;
            // Assert
            Assert.IsInstanceOfType(result.Value, typeof(Motto), "Pas une Devise");
            Assert.AreEqual(new Motto(1, "Dollar", 1.08), (Motto)result.Value, "Devises pas identiques");
        }
    }
}