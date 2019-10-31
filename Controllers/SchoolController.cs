using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using aspnetcore.coreescuela.Models;

namespace aspnetcore.coreescuela.Controllers
{
    public class SchoolController : Controller
    {
        public IActionResult Index(){
            var school = new School();
            school.FoundationYear = 2005;
            school.SchoolId = Guid.NewGuid().ToString();
            school.Name = "Platzi School";
            return View(school);
        }
    }
}
