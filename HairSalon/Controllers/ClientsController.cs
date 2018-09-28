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

        [HttpGet("/clients/new")]
        public ActionResult CreateForm()
        {
          return View(Stylist.GetAll());
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
