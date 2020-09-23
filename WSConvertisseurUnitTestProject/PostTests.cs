using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSConvertisseur.Controllers;
using WSConvertisseur.Models;

namespace WSConvertisseurUnitTestProject
{
    [TestClass]
    public class PostTest
    {
        [TestMethod]
        public void Post_ExistingIdPassed_ReturnsOkObjectResult()
        {
            // Arrange
            var _controller = new MottoController();
            // Act
            var result = _controller.Post(new Motto(4, "test", 1.93)) as OkObjectResult;
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult), "Pas un OkObjectResult");
        }

        [TestMethod]
        public void Post_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Arrange
            var _controller = new MottoController();
            // Act
            var result = _controller.Post(new Motto(1, "test", 1.93));
            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult), "Pas un NotFoundResult");
        }

        [TestMethod]
        public void Post_ExistingPassed_ReturnsRightItem()
        {
            // Arrange
            var _controller = new MottoController();
            // Act
            var result = _controller.Post(new Motto(4, "test", 1.93)) as OkObjectResult;
            // Assert
            Assert.IsInstanceOfType(result.Value, typeof(Motto), "Pas une Devise");
            Assert.AreEqual(new Motto(4, "test", 1.93), (Motto)result.Value, "Devises pas identiques");
        }
    }
}