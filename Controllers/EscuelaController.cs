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
    public class EscuelaController : Controller
    {
        public IActionResult Index(){
            return View();
        }
    }
}
