using System;
using System.Collections.Generic;
using System.Linq;
using aspnetcore.coreescuela.Context;
using aspnetcore.coreescuela.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.coreescuela.Controllers
{
    public class SubjectController : Controller
    {

        private SchoolContext context;

        public SubjectController(SchoolContext context)
        {
            this.context = context;
        }
        public IActionResult MultiSubject()
        {

            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Date = DateTime.Now;
            return View(this.context.Subjects);
        }
        [Route("Subject/Index")]
        [Route("Subject/Index/{subjectId}")]
        public IActionResult Index(string subjectId)
        {
            if (!String.IsNullOrEmpty(subjectId))
            {
                var subject = from su in this.context.Subjects
                              where su.Id == subjectId
                              select su;
                return View(subject.SingleOrDefault());
            }
            else
            {
                return View("MultiSubject",this.context.Subjects);
            }
        }
        [Route("Subject")]
        public IActionResult Index()
        {
            return View(this.context.Subjects.FirstOrDefault());
        }
    }
}