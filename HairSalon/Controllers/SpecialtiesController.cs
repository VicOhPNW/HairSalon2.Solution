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
  }
}
