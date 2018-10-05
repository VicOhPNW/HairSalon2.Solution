using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientsControllerTests
  {
    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      //Arrange
      ClientsController controller = new ClientsController();

      //Act
      ActionResult indexView = controller.Index();

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void CreateForm_ReturnsCorrectView_True()
    {
      //Arrange
      ClientsController controller = new ClientsController();

      //Act
      ActionResult indexView = controller.CreateForm(1);

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Details_ReturnsCorrectView_True()
    {
      //Arrange
      ClientsController controller = new ClientsController();

      //Act
      ActionResult indexView = controller.Details(1);

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void DeleteAllClient_ReturnsCorrectView_True()
    {
      //Arrange
      ClientsController controller = new ClientsController();

      //Act
      ActionResult indexView = controller.DeleteAllClients();

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Update_ReturnsCorrectView_True()
    {
      //Arrange
      ClientsController controller = new ClientsController();

      //Act
      ActionResult indexView = controller.EditClient(1);

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }
  }
}
