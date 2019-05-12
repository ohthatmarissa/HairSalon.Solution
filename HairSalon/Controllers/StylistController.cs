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



    // [HttpGet("/stylist/{stylistName}")]
    // public ActionResult Show(string name)
    // {
    //     Stylist stylist = Stylist.GetByName(name);
    //     return View(stylist);
    // }

  }
}
