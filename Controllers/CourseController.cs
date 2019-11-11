using System;
using System.Collections.Generic;
using System.Linq;
using aspnetcore.coreescuela.Context;
using aspnetcore.coreescuela.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.coreescuela.Controllers
{
    public class CourseController : Controller
    {

        private SchoolContext context;

        public CourseController(SchoolContext context)
        {
            this.context = context;
        }
        public IActionResult MultiCourse()
        {

            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Date = DateTime.Now;
            return View(this.context.Courses);
        }

        public IActionResult Create()
        {
            ViewBag.Date = DateTime.Now;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            ViewBag.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                var school = this.context.Schools.FirstOrDefault();
                course.SchoolId = school.Id;
                this.context.Courses.Add(course);
                this.context.SaveChanges();
                ViewBag.extraMessage = "Curso Creado";
                return View("Index", course);
            }
            else
            {
                return View(course);
            }


        }

        [Route("Course/Edit/{courseId}")]
        public IActionResult Edit(string courseId)
        {

            if (!String.IsNullOrEmpty(courseId))
            {

                var course = this.context.Courses.Where(x=>x.Id == courseId).SingleOrDefault();

                return View("Edit",course);
            }
            else
            {
                return View("MultiCourse", this.context.Courses);
            }
        }

        [HttpPut]
        [Route("Course/Edit/{courseId}")]
        public IActionResult Edit(string courseId, Course coursePut)
        {

            if (!String.IsNullOrEmpty(courseId) && ModelState.IsValid)
            {

                var course = this.context.Courses.Where(x=>x.Id == courseId).SingleOrDefault();

                course.Address = coursePut.Address;
                course.ClassDay = coursePut.ClassDay;
                course.Name = coursePut.Name;
                course.SchoolId = coursePut.SchoolId;

                this.context.Courses.Update(course);
                this.context.SaveChanges();
                ViewBag.extraMessage = "Curso Modificado";
                return View("Index", course);
            }
            else
            {
                return View("MultiCourse", this.context.Courses);
            }
        }

        [Route("Course/Index")]
        [Route("Course/Index/{courseId}")]
        public IActionResult Index(string courseId)
        {
            if (!String.IsNullOrEmpty(courseId))
            {
                var course = from c in this.context.Courses
                             where c.Id == courseId
                             select c;
                return View(course.SingleOrDefault());
            }
            else
            {
                return View("MultiCourse", this.context.Courses);
            }
        }
        [Route("Course")]
        public IActionResult Index()
        {
            return View(this.context.Courses.FirstOrDefault());
        }
    }


}