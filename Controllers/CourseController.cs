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
                return View("MultiCourse",this.context.Courses);
            }
        }
        [Route("Course")]
        public IActionResult Index()
        {
            return View(this.context.Courses.FirstOrDefault());
        }
    }


}