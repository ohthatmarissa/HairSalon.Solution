using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {

    [HttpGet("/stylists")]
    public ActionResult Index()
    {
        List<Stylist> allStylists = Stylist.GetAll();
        return View(allStylists);
    }

    [HttpGet("/stylists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/stylists")]
    public ActionResult Create(string name, int id, string about)
    {
      Stylist myStylist = new Stylist(name, id, about);
      myStylist.Save();
      List<Stylist>allStylists = Stylist.GetAll();
      return RedirectToAction("Index", allStylists);
    }

    // [HttpGet("/stylist/{stylistName}")]
    // public ActionResult Show(string name)
    // {
    //     Stylist stylist = Stylist.GetByName(name);
    //     return View(stylist);
    // }

  }
}
