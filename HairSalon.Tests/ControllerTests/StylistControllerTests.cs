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

      [TestMethod]
      public void Show_ReturnsCorrectView_True()
      {
        StylistController controller = new StylistController();
        ActionResult indexView = controller.Show(1);
        Assert.IsInstanceOfType(indexView, typeof(ViewResult));
      }

      [TestMethod]
      public void DeleteReturnsOk()
      {
        StylistController controller = new StylistController();
        ActionResult actionResult = controller.Delete(1);
        Assert.IsInstanceOfType(actionResult, typeof(RedirectToActionResult));
      }

      [TestMethod]
      public void UpdateReturnsOk()
      {
        StylistController controller = new StylistController();
        ActionResult indexView = controller.Edit(1);
        Assert.IsInstanceOfType(indexView, typeof(ViewResult));
      }
    }
}
