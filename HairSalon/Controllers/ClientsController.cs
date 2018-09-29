using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet("/clients")]
        public ActionResult Index()
        {
            return View(Client.GetAll());
        }

        [HttpGet("/stylists/{id}/new")]
        public ActionResult CreateForm(int id)
        {
          Stylist foundStylist = Stylist.Find(id);
          return View(foundStylist);
        }

        [HttpPost("/clients")]
        public ActionResult Create(string clientName)
        {
          Client newClient = new Client(clientName, (2));
          newClient.Save();
          List<Client> allClients = Client.GetAll();
          return RedirectToAction("Index");
        }
    }
}
