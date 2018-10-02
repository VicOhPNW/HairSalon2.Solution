using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
  public class SpecialtiesController : Controller
  {
    [HttpGet("/specialties")]
    public ActionResult Index()
    {
        return View(Specialty.GetAllSpecialties());
    }

    [HttpGet("/specialties/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [HttpPost("/specialties")]
    public ActionResult CreateSpecialty(string service)
    {
      Specialty newService = new Specialty(service);
      newService.Save();
      List<Specialty> allServices = Specialty.GetAllSpecialties();
      return View("Index", allServices);
    }

    [HttpGet("/specialties/{id}")]
    public ActionResult Details(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty selectedSpecialty = Specialty.Find(id);
      List<Stylist> specialtyStylists = selectedSpecialty.GetStylists();
      List<Stylist> allStylists = Stylist.GetAllStylists();

      model.Add("selectedSpecialty", selectedSpecialty);
      model.Add("specialtyStylists", specialtyStylists);
      model.Add("allStylists", allStylists);
      return View(model);
    }

    [HttpPost("/specialties/{id}/stylists/new")]
    public ActionResult AddStylists(int id)
    {
      Specialty specialty = Specialty.Find(id);
      Stylist stylist =  Stylist.Find(Int32.Parse(Request.Form["stylistId"]));
      specialty.AddStylists(stylist);
      return RedirectToAction("Index");
    }
  }
}
