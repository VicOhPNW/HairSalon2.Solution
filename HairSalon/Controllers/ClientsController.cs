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

        [HttpGet("/clients/delete")]
        public ActionResult DeleteAllClients()
        {
          Client.DeleteAll();
          return RedirectToAction("Index");
        }

        [HttpGet("/clients/{id}/delete")]
        public ActionResult DeleteClient(int id)
        {
          Client selectedClient = Client.Find(id);
          selectedClient.Delete();
          return RedirectToAction("Index");
        }

        [HttpGet("/clients/{id}/update")]
        public ActionResult EditClient(int id)
        {
          Client foundClient = Client.Find(id);
          return View(foundClient);
        }

        [HttpPost("/clients/{id}/update")]
        public ActionResult Update(string editName, int id)
        {
          Client selectedClient = Client.Find(id);
          selectedClient.Edit(editName);
          return RedirectToAction("Index");
        }
    }
}
