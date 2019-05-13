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
      // Client.ClearAll();
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
        Client newClient2 = new Client("Kramer", "test", 1, 1);
        newClient2.Save();
        List<Client> newList = new List<Client> {newClient1, newClient2 };
        List<Client> result = Client.GetAll();
        CollectionAssert.AreEqual(newList, result);
      }


  }
}
