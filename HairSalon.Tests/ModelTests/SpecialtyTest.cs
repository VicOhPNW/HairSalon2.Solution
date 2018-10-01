using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Test
{
  [TestClass]
  public class SpecialtyTests : IDisposable
  {
    public SpecialtyTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=victoria_oh_test;";
    }
      [TestMethod]
      public void GetSpecialty_ReturnsStylistName_String()
      {
        //Arrange
        string stylistName = "Haircut";
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
        Specialty newSpecialty = new Specialty("", 0);

        //Act
        int result = newSpecialty.GetId();

        //Assert
        Assert.AreEqual(id, result);
      }

      [TestMethod]
      public void Equals_ReturnsTrueForSameName_Specialty()
      {
        //Arrange, Act
        Specialty firstSpecialty = new Specialty("Haircut");
        Specialty secondSpecialty = new Specialty("Haircut");

        //Assert
        Assert.AreEqual(firstSpecialty, secondSpecialty);
      }

      [TestMethod]
       public void GetAllSpecialties_SpecialtiesEmptyAtFirst_0()
       {
         //Arrange, Act
         int result = Specialty.GetAllSpecialties().Count;

         //Assert
         Assert.AreEqual(0, result);
       }

      [TestMethod]
      public void Save_SavesSpecialtyToDatabase_SpecialtyList()
      {
        //Arrange
        Specialty testSpecialty = new Specialty("Haircut");
        testSpecialty.Save();

        //Act
        List<Specialty> result = Specialty.GetAllSpecialties();
        List<Specialty> testList = new List<Specialty>{testSpecialty};

        //Assert
        CollectionAssert.AreEqual(testList, result);
      }

     [TestMethod]
     public void Save_DatabaseAssignsIdToSpecialty_Id()
     {
       //Arrange
       Specialty testSpecialty = new Specialty("Haircut");
       testSpecialty.Save();

       //Act
       Specialty savedSpecialty = Specialty.GetAllSpecialties()[0];

       int result = savedSpecialty.GetId();
       int testId = testSpecialty.GetId();

       //Assert
       Assert.AreEqual(testId, result);
     }

     [TestMethod]
     public void Find_FindsSpecialtyInDatabase_Specialty()
     {
       //Arrange
      Specialty testSpecialty = new Specialty("Haircut");
      testSpecialty.Save();

      //Act
      Specialty foundSpecialty = Specialty.Find(testSpecialty.GetId());

      //Assert
      Assert.AreEqual(testSpecialty, foundSpecialty);
     }

     // [TestMethod]
     // public void GetClients_ReturnsAllClientsWithStylists_ClientList()
     // {
     //   //Arrange
     //   Stylist testStylist = new Stylist("Haircut");
     //   testStylist.Save();
     //
     //   Client firstClient = new Client("Victoria", testStylist.GetId());
     //   firstClient.Save();
     //   Client secondClient = new Client("Bob", testStylist.GetId());
     //   secondClient.Save();
     //
     //   //Act
     //   List<Client> testClientList = new List<Client> {firstClient, secondClient};
     //   List<Client> resultClientList = testStylist.GetClients();
     //
     //   //Assert
     //   CollectionAssert.AreEqual(testClientList, resultClientList);
     // }


     public void Dispose()
     {
      Specialty.DeleteAll();
     }
  }
}
