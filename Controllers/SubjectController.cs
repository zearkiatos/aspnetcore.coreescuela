using System;
using System.Collections.Generic;
using aspnetcore.coreescuela.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.coreescuela.Controllers
{
    public class SubjectController : Controller
    {
        public IActionResult MultiSubject()
        {
            var subjects = new List<Subject>(){
                new Subject{
                    Name = "Programación"
                },
                new Subject{
                    Name = "Matemática"
                },
                new Subject{
                    Name = "Educación Física"
                },
                 new Subject{
                    Name = "Castellano"
                },
                new Subject{
                    Name = "Ciencias Naturales"
                }
            };

            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Date = DateTime.Now;
            return View("MultiSubject", subjects);
        }

        public IActionResult Index()
        {
            var subject = new Subject
            {
                Name = "Programación"
            };
            return View(subject);
        }
    }
}