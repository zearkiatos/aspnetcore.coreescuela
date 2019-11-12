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
        [Route("Student/Index")]
        [Route("Student/Index/{studentId}")]
        public IActionResult Index(string studentId)
        {
            if (!String.IsNullOrEmpty(studentId))
            {
                var student = from st in this.context.Students
                              where st.Id == studentId
                              select st;
                return View(student.SingleOrDefault());
            }
            else
            {
                return View("MultiStudent",this.context.Students);
            }
        }
        [Route("Student")]
        public IActionResult Index()
        {
            return View(this.context.Students.FirstOrDefault());
        }

         public IActionResult Create()
        {
            ViewBag.courses = this.context.Courses.ToList();
            ViewBag.Date = DateTime.Now;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            ViewBag.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                this.context.Students.Add(student);
                this.context.SaveChanges();
                ViewBag.extraMessage = "Alumno Creado";
                return View("Index", student);
            }
            else
            {
                return View(student);
            }


        }

        [Route("Student/Edit/{studentId}")]
        public IActionResult Edit(string studentId)
        {

            if (!String.IsNullOrEmpty(studentId))
            {

                var student = this.context.Students.Where(x => x.Id == studentId).SingleOrDefault();
                ViewBag.courses = this.context.Courses.ToList();
                return View("Edit", student);
            }
            else
            {
                return View("MultiStudent", this.context.Students);
            }
        }

        [HttpPost]
        [Route("Student/Edit/{studentId}")]
        public IActionResult Edit(string studentId, Student studentPut)
        {

            if (!String.IsNullOrEmpty(studentId) && ModelState.IsValid)
            {

                var student = this.context.Students.Where(x => x.Id == studentId).SingleOrDefault();

                student.CourseId = studentPut.CourseId;
                student.Name = studentPut.Name;

                this.context.Students.Update(student);
                this.context.SaveChanges();
                ViewBag.extraMessage = "Alumno Modificado";
                return View("Index", student);
            }
            else
            {
                return View("MultiStudent", this.context.Students);
            }
        }

        [Route("Student/Delete/{studentId}")]
        public IActionResult Delete(string studentId)
        {
            if (!String.IsNullOrEmpty(studentId))
            {
                var student = from c in this.context.Students
                             where c.Id == studentId
                             select c;
                return View(student.SingleOrDefault());
            }
            else
            {
                return View("MultiStudent", this.context.Students);
            }
        }
        [HttpGet]
        [Route("Student/ConfirmDelete/{studentId}")]
        public IActionResult ConfirmDelete(string studentId)
        {
            if (!String.IsNullOrEmpty(studentId))
            {
                var student = this.context.Students.FirstOrDefault(x=>x.Id == studentId);
                this.context.Students.Remove(student);
                this.context.SaveChanges();
            }
            return View("MultiStudent",this.context.Students);
        }
    }


}