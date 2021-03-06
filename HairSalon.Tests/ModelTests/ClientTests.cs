using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {
    public void Dispose()
    {
      Client.ClearAll();
    }

    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=marissa_perry_test;";
    }

    [TestMethod]
    public void ClientConstructor_CreatesInstanceOfClient_Client()
    {
      Client newClient = new Client("Jerry", "test", 1);
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string name = "Jerry";
      Client newClient = new Client(name, "test", 1);
      string result = newClient.GetName();
      Assert.AreEqual(name, result);
    }

      [TestMethod]
      public void GetAll_ReturnsClients_ClientList()
      {
        Client newClient1 = new Client("Jerry", "test", 1, 1);
        newClient1.Save();
        Client newClient2 = new Client("Kramer", "test", 2, 2);
        newClient2.Save();
        List<Client> newList = new List<Client> { newClient1, newClient2 };
        List<Client> result = Client.GetAll();
        CollectionAssert.AreEqual(newList, result);
      }

      [TestMethod]
      public void Find_ReturnsCorrectClient_Client()
      {
        Client testClient = new Client("Jerry", "test", 1, 1);
        testClient.Save();
        Client foundClient = Client.Find(testClient.GetId());
        Assert.AreEqual(testClient, foundClient);
      }

      [TestMethod]
      public void Edit_EditsClient_Client()
      {
        string name = "Jerry";
        string about = "Super cute";
        Client client = new Client(name, about, 1);
        client.Save();
        string newName = "Jerri";
        string newAbout = "Changed name";
        Client expectedResult = new Client("Jerri", "Changed name", 1);
        client.Edit(1, newName, newAbout);
        Client actualResult = new Client(client.GetName(), client.GetAbout(), client.GetStylistId());
        Console.WriteLine("Hi" + expectedResult.GetAbout());
        Console.WriteLine("Hi" + actualResult.GetAbout());
        Assert.AreEqual(expectedResult, actualResult);
      }
  }
}
