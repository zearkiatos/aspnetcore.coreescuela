using System;
using System.Collections.Generic;
using System.Linq;
using aspnetcore.coreescuela.Context;
using aspnetcore.coreescuela.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.coreescuela.Controllers
{
    public class StudentController : Controller
    {

        private SchoolContext context;

        public StudentController(SchoolContext context)
        {
            this.context = context;
        }
        public IActionResult MultiStudent()
        {

            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Date = DateTime.Now;
            return View(this.context.Students);
        }

        public IActionResult Index()
        {
            return View(this.context.Students.FirstOrDefault());
        }
    }


}