using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {
    public ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=victoria_oh_test;";
    }

    [TestMethod]
    public void Equals_ReturnsTrueForSameName_Client()
    {
      //Arrange, Act
      Client firstClient = new Client("Victoria", 1);
      Client secondClient = new Client("Victoria", 1);

      //Assert
      Assert.AreEqual(firstClient, secondClient);
    }

    [TestMethod]
    public void GetClientName_ReturnsClientName_String()
    {
      //Arrange
      string clientName = "Victoria";
      Client newClient = new Client(clientName, 1);

      //Act
      string result = newClient.GetClientName();

      //Assert
      Assert.AreEqual(clientName, result);
    }

    [TestMethod]
    public void GetStylistId_ReturnsStylistId_int()
    {
      //Arrange
      int stylistId = 1;
      Client newClient = new Client("", 1);

      //Act
      int result = newClient.GetStylistId();

      //Assert
      Assert.AreEqual(stylistId, result);
    }

    [TestMethod]
    public void GetId_ReturnsClientId_int()
    {
      //Arrange
      int id = 0;
      Client newClient = new Client("", 1, 0);

      //Act
      int result = newClient.GetId();

      //Assert
      Assert.AreEqual(id, result);
    }

    [TestMethod]
    public void Save_SavesClientToDatabase_ClientList()
    {
      //Arrange
      Client testClient = new Client("Victoria", 1);
      testClient.Save();

      //Act
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_SavesClientToDatabase_ClientList()
    {
      //Arrange
      Client testClient = new Client("Victoria", 1);
      testClient.Save();

      //Act
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Find_FindsClientInDatabase_Client()
    {
      //Arrange
      Client testClient = new Client("Mow the lawn", 1);
      testClient.Save();

      //Act
      Client foundClient = Client.Find(testClient.GetId());

      //Assert
      Assert.AreEqual(testClient, foundClient);
    }

    public void Dispose()
    {
      Client.DeleteAll();
      Stylist.DeleteAll();
    }
  }
}
