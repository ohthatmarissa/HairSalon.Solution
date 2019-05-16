using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientControllerTest
    {
      [TestMethod]
      public void Index_ReturnsCorrectView_True()
      {
          ClientController controller = new ClientController();
          ActionResult indexView = controller.Index();
          Assert.IsInstanceOfType(indexView, typeof(ViewResult));
      }

      [TestMethod]
      public void Create_ReturnsCorrectView_True()
      {
        ClientController controller = new ClientController();
        ActionResult indexView = controller.Show(1, 1);
        Assert.IsInstanceOfType(indexView, typeof(ViewResult));
      }
    }
  }
