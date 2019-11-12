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

        [Route("Subject")]
        public IActionResult Index()
        {
            return View(this.context.Subjects.FirstOrDefault());
        }

        public IActionResult Create()
        {
            ViewBag.Date = DateTime.Now;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Subject subject)
        {
            ViewBag.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                this.context.Subjects.Add(subject);
                this.context.SaveChanges();
                ViewBag.extraMessage = "Asignatura Creada";
                return View("Index", subject);
            }
            else
            {
                return View(subject);
            }


        }

        [Route("Subject/Edit/{subjectId}")]
        public IActionResult Edit(string subjectId)
        {

            if (!String.IsNullOrEmpty(subjectId))
            {

                var subject = this.context.Subjects.Where(x => x.Id == subjectId).SingleOrDefault();

                return View("Edit", subject);
            }
            else
            {
                return View("MultiSubject", this.context.Subjects);
            }
        }

        [HttpPost]
        [Route("Subject/Edit/{subjectId}")]
        public IActionResult Edit(string subjectId, Subject subjectPut)
        {

            if (!String.IsNullOrEmpty(subjectId) && ModelState.IsValid)
            {

                var subject = this.context.Subjects.Where(x => x.Id == subjectId).SingleOrDefault();

                subject.SchoolId = subjectPut.SchoolId;
                subject.Name = subjectPut.Name;

                this.context.Subjects.Update(subject);
                this.context.SaveChanges();
                ViewBag.extraMessage = "Asignatura Modificado";
                return View("Index", subject);
            }
            else
            {
                return View("MultiSubject", this.context.Subjects);
            }
        }

        [Route("Subject/Index")]
        [Route("Subject/Index/{subjectId}")]
        public IActionResult Index(string subjectId)
        {
            if (!String.IsNullOrEmpty(subjectId))
            {
                var subject = from c in this.context.Subjects
                             where c.Id == subjectId
                             select c;
                return View(subject.SingleOrDefault());
            }
            else
            {
                return View("MultiSubject", this.context.Subjects);
            }
        }

        [Route("Subject/Delete/{subjectId}")]
        public IActionResult Delete(string subjectId)
        {
            if (!String.IsNullOrEmpty(subjectId))
            {
                var subject = from c in this.context.Subjects
                             where c.Id == subjectId
                             select c;
                return View(subject.SingleOrDefault());
            }
            else
            {
                return View("MultiSubject", this.context.Subjects);
            }
        }
        [HttpGet]
        [Route("Subject/ConfirmDelete/{subjectId}")]
        public IActionResult ConfirmDelete(string subjectId)
        {
            if (!String.IsNullOrEmpty(subjectId))
            {
                var subject = this.context.Subjects.FirstOrDefault(x=>x.Id == subjectId);
                this.context.Subjects.Remove(subject);
                this.context.SaveChanges();
            }
            return View("MultiSubject",this.context.Subjects);
        }
    }
}