using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtiesControllerTests
  {
    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      //Arrange
      SpecialtiesController controller = new SpecialtiesController();

      //Act
      ActionResult indexView = controller.Index();

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void CreateForm_ReturnsCorrectView_True()
    {
      //Arrange
      SpecialtiesController controller = new SpecialtiesController();

      //Act
      ActionResult indexView = controller.CreateForm();

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Details_ReturnsCorrectView_True()
    {
      //Arrange
      SpecialtiesController controller = new SpecialtiesController();

      //Act
      ActionResult indexView = controller.Details(1);

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }
  }
}
