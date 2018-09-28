using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Test
{
  [TestClass]
  public class StylistTests : IDisposable
  {
    public StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=victoria_oh_test;";
    }
      [TestMethod]
      public void GetStylistName_ReturnsStylistName_String()
      {
        //Arrange
        string stylistName = "Panatda";
        Stylist newStylist = new Stylist(stylistName);

        //Act
        string result = newStylist.GetStylistName();

        //Assert
        Assert.AreEqual(stylistName, result);
      }

      [TestMethod]
      public void GetId_Id_int()
      {
        //Arrange
        int id = 0;
        Stylist newStylist = new Stylist("", 0);

        //Act
        int result = newStylist.GetId();

        //Assert
        Assert.AreEqual(id, result);
      }

      [TestMethod]
      public void Equals_ReturnsTrueForSameName_Stylist()
      {
        //Arrange, Act
        Stylist firstName = new Stylist("Panatda");
        Stylist secondName = new Stylist("Panatda");

        //Assert
        Assert.AreEqual(firstName, secondName);
      }

      [TestMethod]
       public void GetAll_StylistsEmptyAtFirst_0()
       {
         //Arrange, Act
         int result = Stylist.GetAll().Count;

         //Assert
         Assert.AreEqual(0, result);
       }

      [TestMethod]
      public void Save_SavesStylistToDatabase_StylistList()
      {
        //Arrange
        Stylist testStylist = new Stylist("Panatda");
        testStylist.Save();

        //Act
        List<Stylist> result = Stylist.GetAll();
        List<Stylist> testList = new List<Stylist>{testStylist};

        //Assert
        CollectionAssert.AreEqual(testList, result);
      }

     [TestMethod]
     public void Save_DatabaseAssignsIdToStylist_Id()
     {
       //Arrange
       Stylist testStylist = new Stylist("Panatda");
       testStylist.Save();

       //Act
       Stylist savedStylist = Stylist.GetAll()[0];

       int result = savedStylist.GetId();
       int testId = testStylist.GetId();

       //Assert
       Assert.AreEqual(testId, result);
     }

     [TestMethod]
     public void Find_FindsStylistInDatabase_Stylist()
     {
       //Arrange
      Stylist testStylist = new Stylist("Panatda");
      testStylist.Save();

      //Act
      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      //Assert
      Assert.AreEqual(testStylist, foundStylist);
     }

     [TestMethod]
     public void GetClients_ReturnsAllClientsWithStylists_ClientList()
     {
       //Arrange
       Stylist testStylist = new Stylist("Panatda");
       testStylist.Save();

       Client firstClient = new Client("Victoria", testStylist.GetId());
       firstClient.Save();
       Client secondClient = new Client("Bob", testStylist.GetId());
       secondClient.Save();

       //Act
       List<Client> testClientList = new List<Client> {firstClient, secondClient};
       List<Client> resultClientList = testStylist.GetClients();

       //Assert
       CollectionAssert.AreEqual(testClientList, resultClientList);
     }

    public void Dispose()
    {
      Stylist.DeleteAll();
      // Item.DeleteAll();
    }
  }
}
