using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {
    [HttpGet("/clients")]
    public ActionResult Index()
    {
        List<Client> allClients = Client.GetAll();
        return View(allClients);
    }

    [HttpPost("/clients")]
    public ActionResult Create(string clientName, string clientAbout, int clientStylistId)
    {
      Client myClient = new Client(clientName, clientAbout, clientStylistId);
      myClient.Save();
      List<Client>allClients = Client.GetAll();
      return RedirectToAction("Index");//, allClients);
    }

    [HttpGet("/clients/{id}")]
    public ActionResult Show(int id)
    {
        Client client = Client.Find(id);
        return View(client);
    }
  }
}
