using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class HairSalonTest : IDisposable
  {
    public void Dispose()
    {
      Stylist.ClearAll();
    }

    public HairSalonTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=marissa_perry_test;";
    }

    [TestMethod]
    public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
    {
      Stylist newStylist = new Stylist("test", 1, "test");
      Assert.AreEqual(typeof(Stylist), newStylist.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string name = "Kelly";
      Stylist newStylist = new Stylist(name, 1, "Test");
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
      Stylist newStylist1 = new Stylist("Kelly", 1, "test");
      newStylist1.Save();
      Stylist newStylist2 = new Stylist("Donna", 2, "test");
      newStylist2.Save();
      List<Stylist> newList = new List<Stylist> { newStylist1, newStylist2 };
      List<Stylist> result = Stylist.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    // [TestMethod]
    // public void Find_ReturnsCorrectStylistFromDatabase_Stylist()
    // {
    //   Stylist testStylist = new Stylist("Kelly", 1, "test");
    //   testStylist.Save();
    //   Stylist foundStylist = Stylist.Find(testStylist.GetId());
    //   Assert.AreEqual(testStylist, foundStylist);
    // }
  }
}
