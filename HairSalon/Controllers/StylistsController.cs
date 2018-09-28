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
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(id);
      List<Client> stylistClients = selectedStylist.GetClients();
      model.Add("selectedStylist", selectedStylist);
      model.Add("stylistClients", stylistClients);
      return View(model);
    }
  }
}
