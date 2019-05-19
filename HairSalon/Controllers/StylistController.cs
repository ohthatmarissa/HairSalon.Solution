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
    public ActionResult Create(string stylistName, string stylistAbout)
    {
      Stylist myStylist = new Stylist(stylistName, stylistAbout);
      myStylist.Save();
      List<Stylist>allStylists = Stylist.GetAll();
      return RedirectToAction("Index");//, allStylists);
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int id)
    {
        Stylist stylist = Stylist.Find(id);
        return View(stylist);
    }

    [HttpPost("/stylists/{stylistId}/delete")]
    public ActionResult Delete(int stylistId)
    {
      Stylist Stylist = Stylist.Find(stylistId);
      Stylist.Delete();

      return RedirectToAction("Index");
    }

    [HttpGet("/stylists/{id}/edit")]
    public ActionResult Edit(int id)
    {
      Stylist selectedStylist = Stylist.Find(id);
      return View(selectedStylist);
    }

    [HttpPost("/stylists/{id}")]
    public ActionResult Update(int id, string newName, string newAbout)
    {
      Stylist selectedStylist = Stylist.Find(id);
      selectedStylist.Edit(id, newName, newAbout);

      return RedirectToAction("Show");
    }
  }
}
