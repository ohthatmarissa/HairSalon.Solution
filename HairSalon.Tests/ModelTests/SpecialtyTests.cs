using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTest : IDisposable
  {
    public void Dispose()
    {
      Specialty.ClearAll();
    }

    public SpecialtyTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=hair_salon_tests;";
    }

    [TestMethod]
    public void SpecialtyConstructor_CreatesInstanceOfSpecialty_Specialty()
    {
      Specialty newSpecialty = new Specialty("color");
      Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      string description = "color";
      Specialty newSpecialty = new Specialty(description, 1);
      string result = newSpecialty.GetDescription();
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_SpecialtyList()
    {
      List<Specialty> newList = new List<Specialty> {};
      List<Specialty> result = Specialty.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsSpecialties_SpecialtyList()
    {
      Specialty newSpecialty1 = new Specialty("color");
      Console.WriteLine("before save " + newSpecialty1.GetId());
      newSpecialty1.Save();
      Specialty newSpecialty2 = new Specialty("long hair");
      Console.WriteLine("after save " + newSpecialty1.GetId());
      newSpecialty2.Save();
      List<Specialty> newList = new List<Specialty> { newSpecialty1, newSpecialty2 };
      List<Specialty> result= Specialty.GetAll();
      Console.WriteLine("Hi" + newList.Count);
      Console.WriteLine("Hi" + result.Count);
      CollectionAssert.AreEqual(newList, result);
    }
  }
}
