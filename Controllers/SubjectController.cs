using System;
using aspnetcore.coreescuela.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.coreescuela.Controllers
{
    public class SubjectController : Controller
    {
         public IActionResult Index()
        {
            var subject = new Subject
            {
                Name = "Programación"
            };
            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Date = DateTime.Now;
            return View(subject);
        }
    }
}