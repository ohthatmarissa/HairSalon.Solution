using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {
    public void Dispose()
    {
      Stylist.ClearAll();
    }

    public StylistTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=marissa_perry_test;";
    }

    [TestMethod]
    public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
    {
      Stylist newStylist = new Stylist("Kelly", "test");
      Assert.AreEqual(typeof(Stylist), newStylist.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string name = "Kelly";
      Stylist newStylist = new Stylist(name, "Test", 1);
      string result = newStylist.GetName();
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_StylistList()
    {
      List<Stylist> newList = new List<Stylist> { };
      List<Stylist> result = Stylist.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsStylists_StylistList()
    {
      Stylist newStylist1 = new Stylist("Kelly", "test", 1);
      newStylist1.Save();
      Stylist newStylist2 = new Stylist("Donna", "test", 1);
      newStylist2.Save();
      List<Stylist> newList = new List<Stylist> { newStylist1, newStylist2 };
      List<Stylist> result = Stylist.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }


    [TestMethod]
    public void Find_ReturnsCorrectStylist_Stylist()
    {
      Stylist testStylist = new Stylist("Kelly", "test");
      testStylist.Save();
      Stylist foundStylist = Stylist.Find(testStylist.GetId());
      Assert.AreEqual(testStylist, foundStylist);
    }

    [TestMethod]
    public void GetClients_ReturnClients_Clients()
    {
      Stylist stylist1 = new Stylist("Kelly", "Test");
      Console.WriteLine("before save " + stylist1.GetId());
      stylist1.Save();
      Console.WriteLine("after save " + stylist1.GetId());
      //int stylistId = stylist1.GetId();
      Client client1 = new Client("Jerry", "test", stylist1.GetId());
      client1.Save();
      Client client2 = new Client("Kramer", "test", stylist1.GetId());
      client2.Save();
      List<Client> listClients = new List<Client>{client1, client2};
      List<Client> foundClients = stylist1.GetClients();
      // Console.WriteLine("Hi" + listClients.Count);
      // Console.WriteLine("Hi" + foundClients.Count);

      CollectionAssert.AreEqual(listClients, foundClients);
    }

    [TestMethod]
    public void Edit_EditsStylist_Stylist()
    {
      string name = "Kelly";
      string about = "Awesome";
      Stylist stylist = new Stylist(name, about);
      stylist.Save();
      string newName = "Kellie";
      string newAbout = "So Good";
      Stylist expectedResult = new Stylist("Kellie", "So Good");
      stylist.Edit(1, newName, newAbout);
      Stylist actualResult = new Stylist(stylist.GetName(), stylist.GetAbout());
      Console.WriteLine("Hi" + expectedResult.GetAbout());
      Console.WriteLine("Hi" + actualResult.GetAbout());
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void Delete_DeletesStylist_Stylist()
    {
      Stylist stylist1 = new Stylist("Kelly", "test");
      stylist1.Save();
      Stylist stylist2 = new Stylist ("Andrea", "test");
      stylist2.Save();
      stylist1.Delete();
      List<Stylist> newList = new List<Stylist> { stylist2 };
      List<Stylist> result = Stylist.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }
  }
}
