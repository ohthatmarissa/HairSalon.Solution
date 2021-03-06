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
      System.Console.WriteLine(clientStylistId);
      Client myClient = new Client(clientName, clientAbout, clientStylistId);
      myClient.Save();
      List<Client>allClients = Client.GetAll();
      return RedirectToAction("Index");//, allClients);
    }

    [HttpGet("/stylists/{clientStylistId}/clients/{id}")]
    public ActionResult Show(int clientStylistId, int id)
    {
        Client client = Client.Find(id);
        return View(client);
    }

    [HttpGet("/clients/{id}/edit")]
    public ActionResult Edit(int id)
    {
      Client selectedClient = Client.Find(id);
      return View(selectedClient);
    }

    [HttpPost("/clients/{id}")]
    public ActionResult Update(int id, string newName, string newAbout)
    {
      Client selectedClient = Client.Find(id);
      selectedClient.Edit(id, newName, newAbout);
      int stylistId = selectedClient.GetStylistId();

      return RedirectToAction("Show", new {clientStylistId = stylistId, id = id});
    }
  }
}
