using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

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

        [HttpGet("/clients/{id}")]
        public ActionResult Details(int id)
        {
          Client selectedClient = Client.Find(id);

          Dictionary<string, object> model = new Dictionary<string, object>();
          model.Add("selectedClient", selectedClient);
          return View(model);
        }

    }
}
