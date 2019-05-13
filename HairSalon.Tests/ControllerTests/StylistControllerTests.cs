using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistControllerTest
    {
      [TestMethod]
      public void Index_ReturnsCorrectView_True()
      {
          StylistController controller = new StylistController();
          ActionResult indexView = controller.Index();
          Assert.IsInstanceOfType(indexView, typeof(ViewResult));
      }

      [TestMethod]
      public void New_ReturnsCorrectView_True()
      {
        StylistController controller = new StylistController();
        ActionResult indexView = controller.New();
        Assert.IsInstanceOfType(indexView, typeof(ViewResult));
      }

      // [TestMethod]
      // public void Show_ReturnsCorrectView_True()
      // {
      //   StylistController controller = new StylistController();
      //   ActionResult indexView = controller.Show();
      //   Assert.IsInstanceOfType(indexView, typeof(ViewResult));
      // }
      // [TestMethod]
      // public void Create_ReturnsCorrectView_True()
      // {
      //   StylistController controller = new StylistController();
      //   ActionResult indexView = controller.Create();
      //   Assert.IsInstanceOfType(indexView, typeof(ViewResult));
      // }
    }
}
