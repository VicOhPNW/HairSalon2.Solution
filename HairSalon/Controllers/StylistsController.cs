using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      return View(Stylist.GetAllStylists());
    }

    [HttpGet("/stylists/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [HttpPost("/stylists")]
    public ActionResult Create(string stylistName)
    {
      Stylist newStylist = new Stylist(stylistName);
      newStylist.Save();
      List<Stylist> allStylists = Stylist.GetAllStylists();
      return View("Index", allStylists);
    }

    [HttpGet("/stylist/{id}")]
    public ActionResult Details(int id)
    {
      Stylist selectedStylist = Stylist.Find(id);
      List<Client> stylistClients = selectedStylist.GetClients();

      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("selectedStylist", selectedStylist);
      model.Add("stylistClients", stylistClients);
      return View(model);
    }

    [HttpPost("/clients/")]
    public ActionResult CreateClient(string clientName, int stylistId)
    {
      Client newClient = new Client(clientName, stylistId);
      newClient.Save();
      Stylist selectedStylist = Stylist.Find(stylistId);
      List<Client> stylistClients = selectedStylist.GetClients();

      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("selectedStylist", selectedStylist);
      model.Add("stylistClients", stylistClients);
      return RedirectToAction("Details", new {id = stylistId});
    }

    [HttpGet("/stylists/delete")]
    public ActionResult DeleteAllStylists()
    {
      Stylist.DeleteAll();
      return RedirectToAction("Index");
    }
  }
}
