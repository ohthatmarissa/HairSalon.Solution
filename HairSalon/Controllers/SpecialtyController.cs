using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class SpecialtyController : Controller
  {
    [HttpGet("/specialties")]
    public ActionResult Index()
    {
        List<Specialty> allSpecialties = Specialty.GetAll();
        return View(allSpecialties);
    }

    [HttpGet("/specialties/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/specialties")]
    public ActionResult Create(string description)
    {
      Specialty mySpecialty = new Specialty(description);
      mySpecialty.Save();
      List<Specialty>allSpecialtys = Specialty.GetAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/specialties/{id}")]
    public ActionResult Show(int id)
    {
      Specialty specialty = Specialty.Find(id);
      return View(specialty);
    }

    [HttpPost("/specialties/{stylistId}/specialties/{id}")]
    public ActionResult Show(int stylistId, int id)
    {
        Specialty specialty = Specialty.Find(id);
        return View(specialty);
    }
  }
}
