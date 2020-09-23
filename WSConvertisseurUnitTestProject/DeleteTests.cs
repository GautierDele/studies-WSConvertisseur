using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using WSConvertisseur.Controllers;
using WSConvertisseur.Models;

namespace WSConvertisseurUnitTestProject
{
    [TestClass]
    public class Delete
    {
        [TestMethod]
        public void Delete_ExistingIdPassed_ReturnsOkObjectResult()
        {
            // Arrange
            var _controller = new MottoController();
            // Act
            var result = _controller.Delete(1) as OkObjectResult;
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult), "Pas un OkObjectResult");
        }

        [TestMethod]
        public void Delete_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Arrange
            var _controller = new MottoController();
            // Act
            var result = _controller.Delete(20);
            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult), "Pas un NotFoundResult");
        }

        [TestMethod]
        public void Delete_ExistingPassed_ReturnsRightItem()
        {
            List<Motto> mottos = new List<Motto>();
            mottos.Add(new Motto(2, "Franc Suisse", 1.07));
            mottos.Add(new Motto(3, "Yen", 120));

            // Arrange
            var _controller = new MottoController();
            // Act
            var result = _controller.Delete(1) as OkObjectResult;
            // Assert
            Assert.IsInstanceOfType(result.Value, typeof(List<Motto>), "Pas une liste de Devises");
            foreach(Motto motto in (List<Motto>) result.Value)
            {
                Assert.AreEqual(mottos.FirstOrDefault((m) => m.Id == motto.Id), motto, "Devises pas identiques");
            }
        }
           
    }
}