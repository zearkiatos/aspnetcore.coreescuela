using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using aspnetcore.coreescuela.Models;
using aspnetcore.coreescuela.Models.Enum;

namespace aspnetcore.coreescuela.Controllers
{
    public class SchoolController : Controller
    {
        public IActionResult Index()
        {
            var school = new School();
            school.FoundationYear = 2005;
            school.UniqueId = Guid.NewGuid().ToString();
            school.Name = "Platzi School";
            school.City = "Bogota";
            school.Country = "Colombia";
            school.Address = "Avenida Siempre Viva";
            school.SchoolType = SchoolType.Secondary;
            ViewBag.CosaDinamica = "La Monja";
            return View(school);
        }
    }
}
